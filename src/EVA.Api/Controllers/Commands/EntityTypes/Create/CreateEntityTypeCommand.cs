using EVA.Application.Dto.Attribute;
using EVA.Application.Dto.EntityType;
using EVA.Application.MediatR.Commands;

namespace EVA.Api.Controllers.Commands.EntityTypes.Create
{
    public class CreateEntityTypeCommand : Command<CreateEntityTypeCommandResult>
    {
        public CreateEntityTypeCommand(EntityTypeDto entity)
        {
            Entity = entity;
        }

        public EntityTypeDto Entity { get; private set; }
    }
}