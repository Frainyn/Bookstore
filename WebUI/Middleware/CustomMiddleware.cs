using Domain.Exceptions;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;
using WebUI.Dto;

namespace WebUI.Middleware
{
    public class CustomMiddleware
    {

        private readonly RequestDelegate _next;
        private readonly ILogger<CustomMiddleware> _logger;

        public CustomMiddleware(RequestDelegate next, ILogger<CustomMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (KeyNotFoundException ex)
            {
                await HandleExceptionAsyc(context, ex.Message, HttpStatusCode.NotFound, "Record not found");
            }
            catch (ArgumentNullException ex)
            {
                await HandleExceptionAsyc(context, ex.Message, HttpStatusCode.NotFound, "Record not found");
            }
            catch (NotFoundAuthorException ex)
            {
                await HandleExceptionAsyc(context, ex.Message, HttpStatusCode.NotFound, ex.Message);
            }
            catch(Exception ex)
            {
                await HandleExceptionAsyc(context, ex.Message, HttpStatusCode.InternalServerError, "Internal server error"); 
            }
        }

        private async Task HandleExceptionAsyc(
            HttpContext context, string exMsg, HttpStatusCode httpStatusCode, string message)
        {
            _logger.LogError(exMsg);

            HttpResponse response = context.Response;

            response.ContentType = "application/json";
            response.StatusCode = (int)httpStatusCode;

            ErrorDto errorDto = new()
            {
                Message = message,
                StatusCode = (int)httpStatusCode,
            };

            string result = JsonSerializer.Serialize(errorDto);

            await response.WriteAsJsonAsync(result);

        }


    }
}
