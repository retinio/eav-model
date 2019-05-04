using System;
using EVA.Application.MediatR.Commands;

namespace EVA.Api.Controllers.Commands.Attributes.Delete
{
    public class DeleteAttributeCommand : Command<DeleteAttributeCommandResult>
    {
        public DeleteAttributeCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
}