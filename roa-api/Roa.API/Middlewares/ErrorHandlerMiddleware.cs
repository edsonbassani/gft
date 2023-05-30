using System.Text.Json;

namespace Roa.API.Middlewares;
public class ErrorHandlerMiddleware
{
  private readonly RequestDelegate _next;

  public ErrorHandlerMiddleware(RequestDelegate next)
  {
    _next = next;
  }

  public async Task InvokeAsync(HttpContext httpContext)
  {
    try
    {
      await _next(httpContext);
    }
    catch (Exception exception)
    {
      await HandleExceptionAsync(httpContext, exception);
    }
  }

  private static Task HandleExceptionAsync<T>(HttpContext context, T exception) where T : Exception
  {
    context.Response.ContentType = "application/json";
    context.Response.StatusCode = 500;
    return context.Response.WriteAsync(new ExceptionResponse
    {
      StatusCode = context.Response.StatusCode,
      Message = exception.Message
    }.ToString());
  }

  private sealed class ExceptionResponse
  {
    public int StatusCode { get; set; }
    public string? Message { get; set; }

    public override string ToString()
    {
      return JsonSerializer.Serialize(this);
    }
  }
}
