using FilterTask.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FilterTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET: api/<HelloController>
        //[ServiceFilter(typeof(ControllerNameFilters), Order = 1)]
        //[ServiceFilter(typeof(ActionNameFilters), Order = 2)]
        //[ServiceFilter(typeof(MethodNameFilters), Order = 3)]

        //[ServiceFilter(typeof(actionFilters), Order = 1)]
        [HttpGet(Name = "Getv")]
        public IEnumerable<string> Get()
        {
            Thread.Sleep(1000);
            return new string[] { "value1", "value2" };
        }
    }
}
