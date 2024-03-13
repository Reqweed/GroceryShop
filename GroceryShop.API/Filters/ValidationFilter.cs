using GroceryShop.DAL.Entities.Exceptions.BadRequestException;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace GroceryShop.API.Filters;

public class ValidationFilter : IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context)
    {
        if (!context.ModelState.IsValid)
        {
            throw new ValidationBadRequestException(FormatModelStateErrors(context.ModelState));
        }
    }

    public void OnActionExecuted(ActionExecutedContext context) { }
    
    private string FormatModelStateErrors(ModelStateDictionary modelState)
    {
        var errors = modelState.Values
            .SelectMany(v => v.Errors)
            .Select(e => e.ErrorMessage)
            .ToList();
        return string.Join(Environment.NewLine, errors);
    }
}