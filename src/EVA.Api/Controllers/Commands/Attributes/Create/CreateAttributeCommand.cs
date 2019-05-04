using EVA.Application.Dto.Attribute;
using EVA.Application.MediatR.Commands;

namespace EVA.Api.Controllers.Commands.Attributes.Create
{
    public class CreateAttributeCommand : Command<CreateAttributeCommandResult>
    {
        public CreateAttributeCommand(AttributeDto attribute)
        {
            Attribute = attribute;
        }

        public AttributeDto Attribute { get; private set; }
    }
}