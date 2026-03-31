using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Api.Filters
{
    public class StudentInfoHeadersFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context) { }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            context.HttpContext.Response.Headers["X-Student-Name"] = "Egorova Yulia Yurievna";
            context.HttpContext.Response.Headers["X-Student-Group"] = "RI-240932";
        }
    }
}