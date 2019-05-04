using EVA.Application.Dto.Attribute;
using EVA.Application.MediatR.Commands;

namespace EVA.Api.Controllers.Commands.Attributes.Update
{
    public class UpdateAttributeCommandResult : CommandResult<AttributeDto>
    {
        public UpdateAttributeCommandResult(int statusCode, string[] errors) : base(statusCode, errors)
        {
        }

        public UpdateAttributeCommandResult(int statusCode, string[] errors, AttributeDto result) : base(statusCode, errors, result)
        {
        }

        public UpdateAttributeCommandResult(AttributeDto result) : base(result)
        {
        }
    }
}