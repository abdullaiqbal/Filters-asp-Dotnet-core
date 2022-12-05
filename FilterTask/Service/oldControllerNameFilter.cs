using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FilterTask.Service
{
    public class oldControllerNameFilter : IResourceFilter
    {
       
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            if (context.ActionDescriptor is ControllerActionDescriptor controllerDescriptor)
            {
                var controllerName = controllerDescriptor.ControllerName;
                context.HttpContext.Response.Headers.Add("Controller Name", controllerDescriptor.ControllerName);
            }
            //throw new NotImplementedException();
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            if (context.ActionDescriptor is ControllerActionDescriptor controllerDescriptor)
            {
                var controllerName = controllerDescriptor.ControllerName;
                context.HttpContext.Response.Headers.Add("Controller Name", controllerDescriptor.ControllerName);
            }
            //throw new NotImplementedException();
        }
    }
}
