using Microsoft.AspNetCore.Diagnostics;
using System.ComponentModel.DataAnnotations;
using ValidationTask.Models;

namespace ValidationTask.Exceptions
{
    public class AppExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            var response = new ErrorMessage();
            if (exception is EmployeeNotFoundException)
            {
                response.StatusCode = StatusCodes.Status404NotFound;
                response.ExceptionMessage = exception.Message;
                response.Title = "Wrong Input";
            }
            else if(exception is ValidationException validationException)
            {
                response.StatusCode = StatusCodes.Status400BadRequest;
                response.ExceptionMessage = validationException.Message;
                response.Title = "Validation Error";
            }
            else
            {
                response.StatusCode = StatusCodes.Status500InternalServerError;
                response.ExceptionMessage = exception.Message;
                response.Title = "Something went Wroung";
            }

            httpContext.Response.StatusCode = response.StatusCode;
            await httpContext.Response.WriteAsJsonAsync(response, cancellationToken);
            return true;
        }
    }
}
