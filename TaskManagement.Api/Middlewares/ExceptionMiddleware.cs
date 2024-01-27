using System.Net;
using TaskManagement.Core.Exceptions;

namespace TaskManagement.Api.Middlewares;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;
    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
    {
        _logger = logger;
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
            _logger.LogError(ex, "Something went wrong");
            
            await HandleExceptionAsync(httpContext, ex);
        }
    }
    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        
        var errorDetails = new ErrorDetails()
        {
            Message = "Internal Server Error",
            StatusCode = 500
        };
        
        switch (exception)
        {
            case TaskNotFoundException e:
                errorDetails.StatusCode = 404;
                context.Response.StatusCode = 404;
                errorDetails.Message = e.Message;
                break;
        }
        
        await context.Response.WriteAsync(errorDetails.ToString());
    }
}