using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;

namespace BuildingSystem.UI.Filters
{
    public class ValidatefilterAttribute:ActionFilterAttribute
    {

        //public override void OnActionExecuting(ActionExecutingContext context)
        //{
        //    if (!context.ModelState.IsValid)
        //    {
        //        var errors = context.ModelState.Values.SelectMany(x=>x.Errors).Select(x=>x.ErrorMessage).ToList();
        //        context.Result= new Bad
        //    }
        //}
    }
}
