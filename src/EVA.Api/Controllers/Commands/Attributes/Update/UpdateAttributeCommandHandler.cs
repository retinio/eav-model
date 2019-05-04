using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using EVA.Application.Dto.Attribute;
using EVA.Infrastructure.Data;
using MediatR;

namespace EVA.Api.Controllers.Commands.Attributes.Update
{
    public class UpdateAttributeCommandHandler : IRequestHandler<UpdateAttributeCommand, UpdateAttributeCommandResult>
    {
        private readonly IEvaUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateAttributeCommandHandler(IEvaUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<UpdateAttributeCommandResult> Handle(UpdateAttributeCommand command, CancellationToken cancellationToken)
        {
            var attribute = await _unitOfWork.AttributeRepository.GetByIdAsync(command.Id);
            if (attribute == null) return new UpdateAttributeCommandResult(404, new[]{$"Attribute not found by #id {command.Id}"});

            attribute.ChangeName(command.Attribute.Name);
            attribute.ChangeDescription(command.Attribute.Name);
            
            var attributeUpdated = await _unitOfWork.AttributeRepository.UpdateAsync(attribute);
            await _unitOfWork.SaveEntitiesAsync(cancellationToken);
            
            return new UpdateAttributeCommandResult(_mapper.Map<AttributeWithIdentityDto>(attributeUpdated));            
        }
    }
}