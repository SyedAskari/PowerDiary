using Newtonsoft.Json;
using PowerDiary.ChatHistory.Application.Exceptions;
using System.Net;

namespace PowerDiary.ChatHistory.Api.Middleware
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                await ConvertException(context, exception);
            }
        }

        private Task ConvertException(HttpContext context, Exception exception)
        {
            HttpStatusCode httpStatusCode = HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";

            var result = string.Empty;

            switch (exception)
            {
                case NotFoundException notFoundException:
                    httpStatusCode = HttpStatusCode.NotFound;
                    break;
                case BadRequestException badRequestException:
                    httpStatusCode = HttpStatusCode.BadRequest;
                    result = badRequestException.Message;
                    break;
                case Exception ex:
                    httpStatusCode = HttpStatusCode.BadRequest;
                    break;
            }
            context.Response.StatusCode = (int)httpStatusCode;

            if (result == String.Empty)
            {
                result = JsonConvert.SerializeObject(new { error = exception.Message });
            };

            return context.Response.WriteAsync(result);
        }
    }
}
