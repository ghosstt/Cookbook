using System;

namespace Cookbook.Api.Features.Common
{
    public class CommandResult<TResult>
    {
        public bool Successful
        {
            get;
            private set;
        }

        public TResult Data
        {
            get;
            private set;
        }

        public Exception Exception
        {
            get;
            private set;
        }

        public CommandResult() { }

        public static CommandResult<TResult> Success()
        {
            return new CommandResult<TResult>()
            {
                Successful = true
            };
        }

        public static CommandResult<TResult> Success(TResult data)
        {
            return new CommandResult<TResult>()
            {
                Successful = true,
                Data = data
            };
        }

        public static CommandResult<TResult> Error(Exception exception)
        {
            return new CommandResult<TResult>()
            {
                Successful = false,
                Exception = exception
            };
        }
    }
}
