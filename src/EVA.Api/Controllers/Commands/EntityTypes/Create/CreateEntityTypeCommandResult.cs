using EVA.Application.Dto.Attribute;
using EVA.Application.Dto.EntityType;
using EVA.Application.MediatR.Commands;

namespace EVA.Api.Controllers.Commands.EntityTypes.Create
{
    public class CreateEntityTypeCommandResult : CommandResult<EntityTypeWithIdentityDto>
    {
        public CreateEntityTypeCommandResult(int statusCode, string[] errors) : base(statusCode, errors)
        {
        }

        public CreateEntityTypeCommandResult(int statusCode, string[] errors, EntityTypeWithIdentityDto result) : base(statusCode, errors, result)
        {
        }

        public CreateEntityTypeCommandResult(EntityTypeWithIdentityDto result) : base(result)
        {
        }
    }
}