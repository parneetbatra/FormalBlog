using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System.Linq;
using System.Net;

namespace FormalBlog.Core.Attributes
{
    public class ValidateAjaxAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            bool isAjax = filterContext.HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest";

            if (!isAjax)
                return;

            var modelState = filterContext.ModelState;
            if (!modelState.IsValid)
            {
                var errorModel =
                        from x in modelState.Keys
                        where modelState[x].Errors.Count > 0
                        select new
                        {
                            key = Core.Helper.ToCamelCase(x),
                            errors = modelState[x].Errors.
                                                          Select(y => y.ErrorMessage).
                                                          ToArray()
                        };

                ContentResult content = new ContentResult();
                content.ContentType = "application/json";
                content.Content = JsonConvert.SerializeObject(errorModel);
                filterContext.Result = content;
                filterContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                base.OnActionExecuting(filterContext);
            }
        }
    }
}
