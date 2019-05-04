using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EVA.Application.Dto;
using EVA.Domain.Entities;
using EVA.Infrastructure.Data;
using MediatR;

namespace EVA.Api.Controllers.Commands.Entities.Create
{
    public class CreateEntityCommandHandler : IRequestHandler<CreateEntityCommand, CreateEntityCommandResult>
    {
        private readonly IEvaUnitOfWork _unitOfWork;

        public CreateEntityCommandHandler(IEvaUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));            
        }

        public async Task<CreateEntityCommandResult> Handle(CreateEntityCommand command, CancellationToken cancellationToken)
        {
            var entityType = await _unitOfWork.EntityTypeRepository.GetByNameAsync(command.Entity.Type);
            if (entityType == null) return new CreateEntityCommandResult(404, new []{ $"Not found entity type by name #{ command.Entity.Type}" });

            var attributes = await _unitOfWork.AttributeRepository.GetByNamesAsync(command.Entity.Attributes.Keys.ToArray());
            var entity = CreateEntity(entityType, attributes, command.Entity.Attributes);

            var newEntity = await _unitOfWork.EntityRepository.AddAsync(entity);
            await _unitOfWork.SaveEntitiesAsync(cancellationToken);

            return new CreateEntityCommandResult(new GuidResultSuccessDto{ Success = true, Id =  newEntity.Id });
        }

        private static Entity CreateEntity(EntityType entityType, IEnumerable<Domain.Attributes.Attribute> attributes, IDictionary<string, object> attributeValues)
        {
            var values = new Dictionary<string, object>(attributeValues, StringComparer.OrdinalIgnoreCase);
            var entity = entityType.CreateEntity();

            foreach (var attribute in attributes)
            {
                entity.AddAttributeValue(attribute, values[attribute.Name]);
            }

            return entity;
        }
    }
}