using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Sinqia.CalculadoraSQIA.Api.Filters
{
    public class ValidadorFiltro : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var erros = context.ModelState.SelectMany(ms => ms.Value.Errors).Select(erro => erro.ErrorMessage).ToList();
                context.Result = new BadRequestObjectResult(erros);
            }
        }
    }
}
