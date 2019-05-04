using MediatR;

namespace EVA.Application.MediatR.Commands
{
    public class Command<T> : IRequest<T> where T: CommandResult
    {
    }
}