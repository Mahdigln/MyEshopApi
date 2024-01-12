using Application.Exceptions;
using System.Net;
using System.Text.Json;
using Error = Application.Response.ErrorHandling.Error;

namespace WebApi.Middlewares.ErrorHandling;

public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {

            var response = context.Response;
            response.ContentType = "application/json";

            Error error = new();

            switch (ex)
            {
                case CustomValidationException validationEx:
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    error.FriendlyMassage = validationEx.FriendlyErrorMassage;
                    error.ErrorMessages = validationEx.ErrorMessages;
                    break;
                default:
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    error.FriendlyMassage = ex.Message;
                    break;
            }

            var result = JsonSerializer.Serialize(error);
            await response.WriteAsync(result);
        }
    }
}
