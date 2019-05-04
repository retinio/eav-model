using EVA.Application.Dto.Attribute;
using EVA.Application.MediatR.Commands;

namespace EVA.Api.Controllers.Commands.Attributes.Create
{
    public class CreateAttributeCommandResult : CommandResult<AttributeWithIdentityDto>
    {
        public CreateAttributeCommandResult(int statusCode, string[] errors) : base(statusCode, errors)
        {
        }

        public CreateAttributeCommandResult(int statusCode, string[] errors, AttributeWithIdentityDto result) : base(statusCode, errors, result)
        {
        }

        public CreateAttributeCommandResult(AttributeWithIdentityDto result) : base(result)
        {
        }
    }
}