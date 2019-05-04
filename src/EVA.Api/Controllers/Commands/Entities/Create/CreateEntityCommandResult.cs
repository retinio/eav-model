using EVA.Application.Dto;
using EVA.Application.Dto.Entities;
using EVA.Application.MediatR.Commands;

namespace EVA.Api.Controllers.Commands.Entities.Create
{
    public class CreateEntityCommandResult : CommandResult<GuidResultSuccessDto>
    {
        public CreateEntityCommandResult(int statusCode, string[] errors) : base(statusCode, errors)
        {
        }

        public CreateEntityCommandResult(int statusCode, string[] errors, GuidResultSuccessDto result) : base(statusCode, errors, result)
        {
        }

        public CreateEntityCommandResult(GuidResultSuccessDto result) : base(result)
        {
        }
    }
}