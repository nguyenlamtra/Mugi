using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Mugi.Web.StaticValue;

namespace COmpStoreClient.Filters
{
    public class ValidateAdmin : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var permission = filterContext.HttpContext.Session.GetString("permission");
            if (permission != StaticValue.PERMISSION_STAFF)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary
                    {
                        { "controller", "LoginStaff" },
                        { "action", "LoginStaff" }
                    });
            }
        }
    }
}
