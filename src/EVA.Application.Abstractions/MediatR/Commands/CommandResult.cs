namespace EVA.Application.MediatR.Commands
{
    public abstract class CommandResult
    {
        protected CommandResult(int statusCode, string[] errors)
        {
            StatusCode = statusCode;
            Errors = errors;
        }
       
        public int StatusCode { get;  }
        
        public string[] Errors { get; }        
    }

    public abstract class CommandResult<T> : CommandResult
    {        
        public T Result { get; set; }

        protected CommandResult(int statusCode, string[] errors) : base(statusCode, errors)
        {            
        }

        protected CommandResult(int statusCode, string[] errors, T result):base(statusCode, errors)
        {
            Result = result;
        }

        protected CommandResult(T result) : base(200, null)
        {            
            Result = result;
        }
    }
}