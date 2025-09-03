using Microsoft.AspNetCore.Mvc;

namespace Kcg.Controllers
{
    [Route("example2")]
    public class ExampleController : Controller
    {
        [HttpGet]
        public string Index()
        {
            return "Index";
        }
        [HttpGet("delete/{id?}")]
        public string Delete(int id)
        {
            return "Delete" + id;
        }
        [HttpPost("delete2")]
        [HttpPost("delete")]
        public string DeletePost()
        {
            return "DeletePost";
        }

    }
}
