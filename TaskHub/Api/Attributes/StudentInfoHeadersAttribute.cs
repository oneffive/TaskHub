using Microsoft.AspNetCore.Mvc.Filters;

namespace Api.Attributes;

public class StudentInfoHeadersAttribute : ActionFilterAttribute
{
    public override void OnActionExecuted(ActionExecutedContext context)
    {
        var headers = context.HttpContext.Response.Headers;

        if (!context.HttpContext.Response.HasStarted)
        {
            headers.Append("X-Student-Name", "Egorova Yulia Yurievna");
            headers.Append("X-Student-Group", "RI-240932");
        }
    }
}