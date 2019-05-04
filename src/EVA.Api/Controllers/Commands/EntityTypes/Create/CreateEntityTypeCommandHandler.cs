using System;
using System.Threading;
using System.Threading.Tasks;
using EVA.Application.Dto.EntityType;
using EVA.Domain.Entities;
using EVA.Infrastructure.Data;
using MediatR;

namespace EVA.Api.Controllers.Commands.EntityTypes.Create
{
    public class CreateEntityTypeCommandHandler : IRequestHandler<CreateEntityTypeCommand, CreateEntityTypeCommandResult>
    {
        private readonly IEvaUnitOfWork _unitOfWork;

        public CreateEntityTypeCommandHandler(IEvaUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<CreateEntityTypeCommandResult> Handle(CreateEntityTypeCommand command, CancellationToken cancellationToken)
        {
            var type = new EntityType(command.Entity.Name.ToLower(), command.Entity.Description);
            var entityType = await _unitOfWork.EntityTypeRepository.AddAsync(type);
            await _unitOfWork.SaveEntitiesAsync(cancellationToken);

            return new CreateEntityTypeCommandResult(new EntityTypeWithIdentityDto
            {
                Id = entityType.Id,
                Name = entityType.Name,
                Description = entityType.Description
            });
        }
    }
}