using System;
using System.Threading;
using System.Threading.Tasks;
using EVA.Application.Dto.Attribute;
using EVA.Domain.Attributes;
using EVA.Infrastructure.Data;
using MediatR;

namespace EVA.Api.Controllers.Commands.Attributes.Create
{
    public class CreateAttributeCommandHandler : IRequestHandler<CreateAttributeCommand, CreateAttributeCommandResult>
    {
        private readonly IEvaUnitOfWork _unitOfWork;

        public CreateAttributeCommandHandler(IEvaUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<CreateAttributeCommandResult> Handle(CreateAttributeCommand command, CancellationToken cancellationToken)
        {
            var attributeType = AttributeType.FromName(command.Attribute.Type.ToString());
            var attribute = attributeType.CreateAttribute(command.Attribute.Name, command.Attribute.Description);

            var newAttribute = await _unitOfWork.AttributeRepository.AddAsync(attribute);
            await _unitOfWork.SaveEntitiesAsync(cancellationToken);
            
            return new CreateAttributeCommandResult( new AttributeWithIdentityDto
            {
                Id = newAttribute.Id,
                Type = command.Attribute.Type,
                Name = command.Attribute.Name,
                Description = command.Attribute.Description
            });
        }
    }
}