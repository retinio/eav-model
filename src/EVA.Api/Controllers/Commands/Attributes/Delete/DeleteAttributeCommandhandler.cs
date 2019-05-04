using System;
using System.Threading;
using System.Threading.Tasks;
using EVA.Application.Dto;
using EVA.Infrastructure.Data;
using MediatR;

namespace EVA.Api.Controllers.Commands.Attributes.Delete
{
    public class DeleteAttributeCommandHandler : IRequestHandler<DeleteAttributeCommand, DeleteAttributeCommandResult>
    {
        private readonly IEvaUnitOfWork _unitOfWork;

        public DeleteAttributeCommandHandler(IEvaUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<DeleteAttributeCommandResult> Handle(DeleteAttributeCommand command, CancellationToken cancellationToken)
        {
            var attribute = await _unitOfWork.AttributeRepository.GetByIdAsync(command.Id);
            if (attribute == null) return new DeleteAttributeCommandResult(404, new []{ $"Not found attribute by id #{command.Id}"});

            await _unitOfWork.AttributeRepository.DeleteAsync(attribute);
            var result = await _unitOfWork.SaveEntitiesAsync(cancellationToken);

            return new DeleteAttributeCommandResult(new ResultSuccessDto{Success = result});
        }
    }
}