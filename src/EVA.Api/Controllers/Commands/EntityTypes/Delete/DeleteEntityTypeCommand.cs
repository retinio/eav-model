using System;
using EVA.Application.MediatR.Commands;

namespace EVA.Api.Controllers.Commands.EntityTypes.Delete
{
    public class DeleteEntityTypeCommand : Command<DeleteEntityTypeCommandResult>
    {
        public DeleteEntityTypeCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
}