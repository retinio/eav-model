namespace EVA.Application.MediatR.Queries
{
    public abstract class QueryResult
    {
        protected QueryResult(int statusCode, string[] errors)
        {
            Errors = errors;
            StatusCode = statusCode;
        }
        
        public string[] Errors { get; }

        public int StatusCode { get;  }

    }

    public abstract class QueryResult<T> : QueryResult
    {
        public QueryResult(int statusCode, string[] errors) : base(statusCode, errors)
        {
        }

        protected QueryResult(T result) : base(200, null)
        {
            Result = result;
        }

        public T Result { get; }        
    }
}