using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;

namespace BuildingSystem.UI.Filters
{
   public class ModelStateFilterAttribute : ActionFilterAttribute
   {
       public override void OnActionExecuting(ActionExecutingContext context)
       {
             if (!context.ModelState.IsValid)
             {
                var controller = context.Controller as Controller;
                var model = context.ActionArguments?.Count > 0
                   ? context.ActionArguments.First().Value
                   : null;
                context.Result = (IActionResult)controller?.View(model)
                   ?? new BadRequestResult();
             }
            base.OnActionExecuting(context);
       }
    }
}
