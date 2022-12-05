using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Diagnostics;

namespace FilterTask.Service
{
    public class MethodNameFilters : IActionFilter
    {


        private void Log(string methodName, RouteData routeData)
        {
            var actionExecuting = routeData.Values["Action Executing..."];
            Debug.WriteLine(actionExecuting);
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.ActionDescriptor is ControllerActionDescriptor controllerDescriptor)
            {
                var methodName = controllerDescriptor.MethodInfo;
                context.HttpContext.Response.Headers["Method-Name"] = methodName.Name;
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            Log("OnActionExecuted", context.RouteData);
        }
    }
}
