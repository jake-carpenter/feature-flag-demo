using Microsoft.AspNetCore.Mvc;
using Microsoft.FeatureManagement;
using Microsoft.FeatureManagement.Mvc;

namespace FeatureFlagDemo
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

        [HttpGet("foo1")]
        public ActionResult<string> FooExample1()
        {
            if (!FeatureManager.IsEnabled(FeatureFlags.Foo))
                return NotFound();

            return nameof(FeatureFlags.Foo);
        }

        [HttpGet("foo2")]
        [FeatureGate(FeatureFlags.Foo)]
        public ActionResult<string> FooExample2()
        {
            return nameof(FeatureFlags.Foo);
        }

        [HttpGet("bar")]
        [FeatureGate(FeatureFlags.Bar)]
        public ActionResult<string> BarExample()
        {
            return nameof(FeatureFlags.Bar);
        }
    }
}
