using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace Api.Attributes;

public class ResponseTimeHeaderAttribute : ActionFilterAttribute
{
    private Stopwatch stopwatch = new Stopwatch();

    public override void OnActionExecuting(ActionExecutingContext context)
    {
        stopwatch.Start();
    }

    public override void OnActionExecuted(ActionExecutedContext context)
    {
        stopwatch.Stop();

        var headers = context.HttpContext.Response.Headers;

        if (!context.HttpContext.Response.HasStarted)
        {
            headers.Append("X-Response-Time-Ms", stopwatch.ElapsedMilliseconds.ToString());
        }
    }
}