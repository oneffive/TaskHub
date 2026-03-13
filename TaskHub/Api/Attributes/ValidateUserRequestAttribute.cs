using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Api.Attributes;

public class ValidateUserRequestAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        var request = context.ActionArguments.Values.FirstOrDefault();

        if (request == null)
        {
            context.Result = new BadRequestObjectResult("Тело запроса отсутствует");
            return;
        }

        var nameProp = request.GetType().GetProperty("Name");

        if (nameProp != null)
        {
            var value = nameProp.GetValue(request) as string;

            if (string.IsNullOrWhiteSpace(value))
            {
                context.Result = new BadRequestObjectResult("Имя пользователя не задано");
                return; 
            }
        }
    }
}