using EVA.Application.Dto;
using EVA.Application.MediatR.Commands;

namespace EVA.Api.Controllers.Commands.EntityTypes.Delete
{
    public class DeleteEntityTypeCommandResult : CommandResult<ResultSuccessDto>
    {
        public DeleteEntityTypeCommandResult(int statusCode, string[] errors) : base(statusCode, errors)
        {
        }

        public DeleteEntityTypeCommandResult(int statusCode, string[] errors, ResultSuccessDto result) : base(statusCode, errors, result)
        {
        }

        public DeleteEntityTypeCommandResult(ResultSuccessDto result) : base(result)
        {
        }
    }
}