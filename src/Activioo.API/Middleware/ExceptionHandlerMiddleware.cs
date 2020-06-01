using System;
using System.Net;
using System.Threading.Tasks;
using Activioo.Domain.Exceptions;
using Activioo.Infrastructure.Exceptions;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Activioo.API.Middleware
{
  public class ExceptionHandlerMiddleware
  {
    private readonly RequestDelegate _request;

    public ExceptionHandlerMiddleware(RequestDelegate request)
    {
      _request = request;
    }

    public async Task Invoke(HttpContext context)
    {
      try
      {
        await _request(context);
      }
      catch (Exception ex)
      {
        await HandleExceptionAsync(context, ex);
      }
    }

    private Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
      string errorMessage;
      HttpStatusCode errorCode;
      var exceptionType = ex.GetType();
      switch (ex)
      {
        case { } e when exceptionType == typeof(UnauthorizedAccessException):
          errorCode = HttpStatusCode.Unauthorized;
          errorMessage = "access_unauthorized";
          break;

        case InfrastructureException e when exceptionType == typeof(InfrastructureException):
          errorCode = e.Code;
          errorMessage = e.ErrorMessage;
          break;

        case DomainException e when exceptionType == typeof(DomainException):
          errorCode = e.Code;
          errorMessage = e.ErrorMessage;
          break;

        default:
          errorCode = HttpStatusCode.InternalServerError;
          errorMessage = "internalServerError";
          break;
      }

      var response = new {ErrorCode = errorCode, ErrorMessage = errorMessage};
      var payload = JsonConvert.SerializeObject(response, Formatting.Indented);
      context.Response.ContentType = "application/json";
      context.Response.StatusCode = (int)errorCode;

      return context.Response.WriteAsync(payload);
    }
  }
}