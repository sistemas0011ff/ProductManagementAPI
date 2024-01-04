using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Extensions.Logging; 
using System.Diagnostics; 

namespace ProductManagementAPI.Infrastructure.Logging
{
    public class ResponseTimeLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ResponseTimeLoggingMiddleware> _logger;

        public ResponseTimeLoggingMiddleware(RequestDelegate next, ILogger<ResponseTimeLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        { 
            var requestId = Guid.NewGuid().ToString();
            var stopwatch = Stopwatch.StartNew();

            try
            {
                _logger.LogInformation("Starting request: {RequestId}, {Method}, {Url}",
                    requestId, context.Request.Method, context.Request.GetDisplayUrl());

                await _next(context);

                stopwatch.Stop();
                _logger.LogInformation("Request completed: {RequestId}, {Method}, {Url}, StatusCode: {StatusCode}, Duration: {Duration}ms",
                    requestId, context.Request.Method, context.Request.GetDisplayUrl(), context.Response.StatusCode, stopwatch.ElapsedMilliseconds);
            }
            catch (Exception ex)
            {
                stopwatch.Stop();
                _logger.LogError(ex, "Request failed: {RequestId}, {Method}, {Url}, StatusCode: {StatusCode}, Duration: {Duration}ms",
                    requestId, context.Request.Method, context.Request.GetDisplayUrl(), context.Response.StatusCode, stopwatch.ElapsedMilliseconds);

                throw;  
            }
        }
    }
}
