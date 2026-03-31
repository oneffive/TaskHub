using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace Api.Filters
{
    public class RequestLoggingFilter : IActionFilter
    {
        private readonly ILogger<RequestLoggingFilter> _logger;
        private Stopwatch _stopwatch = null!;

        public RequestLoggingFilter(ILogger<RequestLoggingFilter> logger)
        {
            _logger = logger;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            _stopwatch = new Stopwatch();
            _stopwatch.Start();
            var httpMethod = context.HttpContext.Request.Method;
            var path = context.HttpContext.Request.Path;
            _logger.LogInformation($"Начало выполнения: {httpMethod} {path}");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            _stopwatch.Stop();
            var statusCode = context.HttpContext.Response.StatusCode;
            var elapsed = _stopwatch.ElapsedMilliseconds;
            _logger.LogInformation($"Завершение: статус {statusCode}, время {elapsed} мс");
        }
    }
}