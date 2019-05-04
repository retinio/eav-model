using MediatR;

namespace EVA.Application.MediatR.Queries
{
    public class Query<T> : IRequest<T> where T : QueryResult
    {        
    }
}