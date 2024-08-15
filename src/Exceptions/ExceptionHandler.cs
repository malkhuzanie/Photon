using System.Net.Mime;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Photon.Exceptions;

public class ExceptionHandler(ProblemDetailsFactory problemDetailsFactory) : IExceptionHandler
{
  public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception,
    CancellationToken cancellationToken)
  {
    httpContext.Response.ContentType = MediaTypeNames.Application.ProblemJson;
    httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
    await httpContext.Response.WriteAsJsonAsync(
      problemDetailsFactory.CreateProblemDetails(
        httpContext,
        statusCode: StatusCodes.Status500InternalServerError,
        detail: exception.Message
      ),
      cancellationToken
    );
    return true;
  }

  // public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, ValidationException exception)
  // {
  //   
  // }
}