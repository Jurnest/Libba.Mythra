using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Libba.Mythra.Presentation.WebAPI.ActionFilters;

public class ValidateModelActionFilter : IActionFilter
{
    private readonly ILogger<ValidateModelActionFilter> _logger;

    public ValidateModelActionFilter(ILogger<ValidateModelActionFilter> logger)
    {
        _logger = logger;
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
        if (!context.ModelState.IsValid)
        {
            context.Result = new BadRequestObjectResult(context.ModelState);
            _logger.LogWarning("Model Valid Değil");
        }
        _logger.LogInformation("Model Valid.");
    }

    public void OnActionExecuted(ActionExecutedContext context) { }
}