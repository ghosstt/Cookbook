using Cookbook.Api.Helpers.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace Cookbook.Api.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var ex = context.Exception;
            var error = new ApiError();
            error.ErrorMessage = ex.Message;

            if (ex is ApiException)
            {
                error.StatusCode = 500;
                context.HttpContext.Response.StatusCode = error.StatusCode;
            }
            else if (ex is UnauthorizedAccessException)
            {
                error.StatusCode = 401;
            }
            else
            {
                error.ErrorMessage = context.Exception.GetBaseException().Message;
                error.StackTrace = context.Exception.StackTrace;
                error.StatusCode = 500;
            }

            context.HttpContext.Response.StatusCode = error.StatusCode;
            context.Result = new JsonResult(error);
        }
    }
}
