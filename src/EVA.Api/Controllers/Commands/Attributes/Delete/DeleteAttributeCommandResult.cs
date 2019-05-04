using EVA.Application.Dto;
using EVA.Application.MediatR.Commands;

namespace EVA.Api.Controllers.Commands.Attributes.Delete
{
    public class DeleteAttributeCommandResult : CommandResult<ResultSuccessDto>
    {
        public DeleteAttributeCommandResult(int statusCode, string[] errors) : base(statusCode, errors)
        {
        }

        public DeleteAttributeCommandResult(int statusCode, string[] errors, ResultSuccessDto result) : base(statusCode, errors, result)
        {
        }

        public DeleteAttributeCommandResult(ResultSuccessDto result) : base(result)
        {
        }
    }
}