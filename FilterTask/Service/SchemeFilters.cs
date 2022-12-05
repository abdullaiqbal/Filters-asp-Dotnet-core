//using Microsoft.AspNetCore.Mvc.Controllers;
//using Microsoft.AspNetCore.Mvc.Filters;
//using Microsoft.OpenApi.Models;
//using Swashbuckle.AspNetCore.Examples;
//using Swashbuckle.AspNetCore.SwaggerGen;
//using System.Diagnostics;
//using System.Globalization;

//namespace FilterTask.Service
//{
//    public class RouteFilters : IOperationFilter
//    {
//        public void Apply(OpenApiOperation operation, OperationFilterContext context)
//        {
//            var actionAttributes = context.GetControllerAndActionAttributes<SwaggerResponseHeaderAttribute>();

//            foreach (var attr in actionAttributes)
//            {
//                foreach (var statusCode in attr.StatusCodes)
//                {
//                    var response = operation.Responses.FirstOrDefault(x => x.Key == (statusCode).ToString(CultureInfo.InvariantCulture)).Value;

//                    if (response != null)
//                    {
//                        if (response.Headers == null)
//                        {
//                            response.Headers = new Dictionary<string, OpenApiHeader>();
//                        }

//                        response.Headers.Add(attr.Name, new OpenApiHeader { Description = attr.Description, Schema = new OpenApiSchema { Description = attr.Description, Type = attr.Type, Format = attr.Format } });
//                    }
//                }
//            }
//        }
//    }
//}
