using OrderProcessing.API.Models.Exception;
using OrderProcessing.DataAccess.Exceptions;
using System.Diagnostics;
using System.Net;

namespace OrderProcessing.API.Middleware
{
    /// <summary>
    /// // Middleware for handling exceptions and generating consistent error responses
    /// </summary>
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;
        public ExceptionMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            _configuration = configuration;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        /// <summary>
        /// Method to handle exceptions and send consistent error responses
        /// </summary>
        /// <param name="httpContext"></param>
        /// <param name="exception"></param>
        /// <returns> returns the ExceptionResponse</returns>
        private async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {
            httpContext.Response.ContentType = "application/json";
            HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
            var apiId = _configuration["ApiSettings:Api_id"];
            ExceptionDto exResponse = new ExceptionDto();
            // Switch statement to handle specific exception types
            switch (exception)
            {
                case BadRequestException badRequestException:
                    exResponse.Api_id = apiId;
                    exResponse.Severity = TraceLevel.Info.ToString();
                    exResponse.Response_code = (int)HttpStatusCode.BadRequest;
                    exResponse.Response_message = !string.IsNullOrEmpty(badRequestException.Message) ? badRequestException.Message : "Internal application server error please check the logs";
                    exResponse.Created_datetime = DateTime.UtcNow;
                    break;
                case NotFoundException notFoundException:
                    exResponse.Api_id = apiId;
                    exResponse.Severity = TraceLevel.Info.ToString();
                    exResponse.Response_code = (int)HttpStatusCode.NotFound;
                    exResponse.Response_message = notFoundException.Message;
                    exResponse.Created_datetime = DateTime.UtcNow;
                    break;
                default:
                    // Default case for other exceptions
                    exResponse.Api_id = apiId;
                    exResponse.Severity = TraceLevel.Error.ToString();
                    exResponse.Response_code = (int)statusCode;
                    exResponse.Response_message = exception.Message;
                    exResponse.Created_datetime = DateTime.UtcNow;
                    break;
            }
            //Set the HTTP status code for the response and write the exception response as JSON to the response stream
            httpContext.Response.StatusCode = (int)statusCode;
            await httpContext.Response.WriteAsJsonAsync(exResponse);
        }
    }
}
