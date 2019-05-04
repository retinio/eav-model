using System;
using EVA.Application.Dto.Attribute;
using EVA.Application.MediatR.Commands;

namespace EVA.Api.Controllers.Commands.Attributes.Update
{
    public class UpdateAttributeCommand : Command<UpdateAttributeCommandResult>
    {
        public UpdateAttributeCommand(Guid id, AttributeWithOutTypeDto attribute)
        {
            Id = id;
            Attribute = attribute;
        }

        public Guid Id { get; private set; }

        public AttributeWithOutTypeDto Attribute { get; private set; }
    }
}