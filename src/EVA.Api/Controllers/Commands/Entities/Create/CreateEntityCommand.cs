using EVA.Application.Dto.Entities;
using EVA.Application.MediatR.Commands;

namespace EVA.Api.Controllers.Commands.Entities.Create
{
    public class CreateEntityCommand : Command<CreateEntityCommandResult>
    {
        public CreateEntityCommand(EntityDto entity)
        {
            Entity = entity;
        }

        public EntityDto Entity { get; private set; }
    }
}