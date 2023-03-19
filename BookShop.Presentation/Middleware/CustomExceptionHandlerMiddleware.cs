namespace BookShop.Presentation.Middleware
{
    using BookShop.Application.Common.Exceptions;
    using global::BookShop.Application.Common.Exceptions;
    using Microsoft.AspNetCore.Diagnostics;
    using Microsoft.Extensions.Options;
    using System.Diagnostics;
    using System.Net;
    using System.Text.Json;

        public class CustomExceptionHandlerMiddleware
        {
            private readonly RequestDelegate _next;
            public CustomExceptionHandlerMiddleware(RequestDelegate next) =>
                _next = next;

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

            private Task HandleExceptionAsync(HttpContext context, Exception ex)
            {
                var code = HttpStatusCode.InternalServerError;
                var result = string.Empty; // to serialize the result into Json

                switch (ex)
                {
                    case NotFoundException notFoundException:
                        code = HttpStatusCode.OK;
                        break;
                }

                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)code;

                if (result == string.Empty)
                {
                    result = JsonSerializer.Serialize(new { error = ex.Message });
                }

                return context.Response.WriteAsync(result);
            }
        }
}
