using Microsoft.AspNetCore.Mvc;

namespace FeatureFlagDemo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> Get()
        {
            return "hello world";
        }
    }
}
