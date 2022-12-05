using FilterTask.Service.IServices;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace FilterTask.Service
{
    public class actionFilters : ActionFilterAttribute, IActionFilter
    {

        public void OnActionExecuted(ActionExecutedContext context)
        {
            //Controller Name Filter
            var ControllerName = context.RouteData.Values["controller"].ToString();
            context.HttpContext.Response.Headers.Add("ControllerName", ControllerName);
            //Action Name Filter
            var ActionName = context.RouteData.Values["action"].ToString();
            context.HttpContext.Response.Headers.Add("ActionName", ActionName);
            //Display Scheme Filter
            var Scheme = context.HttpContext.Request.Scheme+ ":" + context.HttpContext.Request.Host;
            context.HttpContext.Response.Headers.Add("Scheme", Scheme);
            //Port Filter
            var Port = context.HttpContext.Connection.LocalPort.ToString();
            context.HttpContext.Response.Headers.Add("Port", Port);
            //HostFilter
            var Host = context.HttpContext.Request.Host.ToString();
            context.HttpContext.Response.Headers.Add("Host", Host);
            ////Response Time Filter
            //IStopwatch watch = GetStopwatch(context.HttpContext);
            //watch.Stop();
            //string value = string.Format("{0}ms", watch.ElapsedMilliseconds);
            //context.HttpContext.Response.Headers["X-Action-Response-Time"] = value;

            //base.OnActionExecuted(context);
            //throw new NotImplementedException();
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            //IStopwatch watch = GetStopwatch(context.HttpContext);
            //// watch.Reset();
            //watch.Start();
            Log("OnActionExecuting", context.RouteData);
        }

        private void Log(string methodName, RouteData routeData)
        {
            var actionExecuting = routeData.Values["Action Executing"];
            Debug.WriteLine(actionExecuting);
        }

        //private IActionResponseTimeStopwatch GetStopwatch(HttpContext context)
        //{
        //    return context.RequestServices.GetService<IActionResponseTimeStopwatch>();
        //}
    }
}
