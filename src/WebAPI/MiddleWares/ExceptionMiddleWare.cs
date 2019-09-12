using System;
using System.Net;
using System.Threading.Tasks;
using ApplicationServices.Exceptions;
using Microsoft.AspNetCore.Http;

namespace WebAPI.MiddleWares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
    
        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }
    
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }
    
        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
    
            string response = CreateResponse(context, exception);

            return context.Response.WriteAsync(response);
        }

        private string CreateResponse(HttpContext context, Exception exception)
        {
            string message = "Sorry, there is an error.";
            if(exception is BusinessException)
                message = exception.Message;

            string response =  $@"{{ ""StatusCode"" = ""{context.Response.StatusCode}"",
                ""Message"" = ""{message}""}}";

            return response;
        }
    }
}