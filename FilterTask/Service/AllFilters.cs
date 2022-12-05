using FilterTask.Service.IServices;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace FilterTask.Service
{
    [AttributeUsage(validOn: AttributeTargets.Class | AttributeTargets.Method)]
    public class AllFilters : Attribute, IActionFilter
    {
        
            private IActionResponseTimeStopwatch GetStopwatch(HttpContext context)
            {
                return context.RequestServices.GetService<IActionResponseTimeStopwatch>();
            }

            public void OnActionExecuting(ActionExecutingContext context)
            {
                IStopwatch watch = GetStopwatch(context.HttpContext);
               // watch.Reset();
                watch.Start();
            }
            public void OnActionExecuted(ActionExecutedContext context)
            {
                IStopwatch watch = GetStopwatch(context.HttpContext);
                watch.Stop();
                string value = string.Format("{0}ms", watch.ElapsedMilliseconds);
                context.HttpContext.Response.Headers["X-Action-Response-Time"] = value;

            //other
            var ControllerName = context.RouteData.Values["controller"].ToString();
            context.HttpContext.Response.Headers.Add("ControllerName", ControllerName);
            //Action Name Filter
            var ActionName = context.RouteData.Values["action"].ToString();
            context.HttpContext.Response.Headers.Add("ActionName", ActionName);
            ////Method Name
            if (context.ActionDescriptor is ControllerActionDescriptor controllerDescriptor)
            {
                var methodName = controllerDescriptor.MethodInfo;
                context.HttpContext.Response.Headers["Method-Name"] = methodName.Name;
            }
            //Display Scheme Filter
            var Scheme = context.HttpContext.Request.Scheme + ":" + context.HttpContext.Request.Host;
            context.HttpContext.Response.Headers.Add("Scheme", Scheme);
            //Port Filter
            var Port = context.HttpContext.Connection.LocalPort.ToString();
            context.HttpContext.Response.Headers.Add("Port", Port);
            //HostFilter
            var Host = context.HttpContext.Request.Host.ToString();
            context.HttpContext.Response.Headers.Add("Host", Host);
        }
        }


        public interface IActionResponseTimeStopwatch : IStopwatch
        {
        public async Task Invoke(HttpContext context)
        {
            var watch = new Stopwatch();
            watch.Start();
            /*others same*/
        }
    }

        public class ActionResponseTimeStopwatch : Stopwatch, IActionResponseTimeStopwatch
        {
            public ActionResponseTimeStopwatch() : base()
            {
            }
        }
 }

