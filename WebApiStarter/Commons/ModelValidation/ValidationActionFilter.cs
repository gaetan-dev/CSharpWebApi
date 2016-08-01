using System.Linq;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using WebApiStarter.Layers.ExceptionLayer;

namespace WebApiStarter.Commons.ModelValidation
{
    public class ValidationActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (!actionContext.ModelState.IsValid)
            {
                var errors = actionContext.ModelState
                    .Where(e => e.Value.Errors.Count > 0)
                    .Select(e => new ValidationError
                    {
                        Name = e.Key,
                        Message = e.Value.Errors.First().Exception.ToString()
                    }.ToString()).ToArray();

                CustomExceptionService.ThrowModelNotValidException(string.Join(",", errors));
            }
        }
    }
}