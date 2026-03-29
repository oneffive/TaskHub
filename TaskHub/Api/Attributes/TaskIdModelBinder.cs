using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Threading.Tasks;

namespace Api.Attributes
{
    public class TaskIdModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            var routeData = context.ActionContext.RouteData.Values;
            
            if (!routeData.TryGetValue("id", out var idValue) || idValue == null || string.IsNullOrWhiteSpace(idValue.ToString()))
            {
                context.ModelState.AddModelError(context.ModelName, "Идентификатор задачи не задан");
                context.Result = ModelBindingResult.Failed();
                return Task.CompletedTask;
            }

            var idString = idValue.ToString();

            if (!Guid.TryParse(idString, out var guidValue))
            {
                context.ModelState.AddModelError(context.ModelName, "Идентификатор задачи имеет некорректный формат");
                context.Result = ModelBindingResult.Failed();
                return Task.CompletedTask;
            }

            context.Result = ModelBindingResult.Success(guidValue);
            return Task.CompletedTask;
        }
    }
}