using Microsoft.AspNetCore.Mvc;
using Microsoft.FeatureManagement;

namespace FeatureFlagDemo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        public TestController(IFeatureManager featureManager)
        {
            FeatureManager = featureManager;
        }

        public IFeatureManager FeatureManager { get; }

        [HttpGet]
        public ActionResult<string> Get()
        {
            return "hello world";
        }

        [HttpGet("foo")]
        public ActionResult<string> Foo()
        {
            if (!FeatureManager.IsEnabled(FeatureFlags.Foo))
                return NotFound();

            return nameof(FeatureFlags.Foo);
        }
    }
}
