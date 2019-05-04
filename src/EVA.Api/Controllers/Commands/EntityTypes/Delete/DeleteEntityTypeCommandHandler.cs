using System;
using System.Threading;
using System.Threading.Tasks;
using EVA.Application.Dto;
using EVA.Infrastructure.Data;
using MediatR;

namespace EVA.Api.Controllers.Commands.EntityTypes.Delete
{
    public class DeleteEntityTypeCommandHandler : IRequestHandler<DeleteEntityTypeCommand, DeleteEntityTypeCommandResult>
    {
        private readonly IEvaUnitOfWork _unitOfWork;

        public DeleteEntityTypeCommandHandler(IEvaUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<DeleteEntityTypeCommandResult> Handle(DeleteEntityTypeCommand command, CancellationToken cancellationToken)
        {
            var attribute = await _unitOfWork.EntityTypeRepository.GetByIdAsync(command.Id);
            if (attribute == null) return new DeleteEntityTypeCommandResult(404, new []{ $"Not found entity type by id #{command.Id}"});

            await _unitOfWork.EntityTypeRepository.DeleteAsync(attribute);
            var result = await _unitOfWork.SaveEntitiesAsync(cancellationToken);

            return new DeleteEntityTypeCommandResult(new ResultSuccessDto{Success = result});
        }
    }
}