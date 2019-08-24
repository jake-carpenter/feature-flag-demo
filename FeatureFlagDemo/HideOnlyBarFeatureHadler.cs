using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.FeatureManagement.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeatureFlagDemo
{
    public class OnlyHideBarFeatureHandler : IDisabledFeaturesHandler
    {
        public Task HandleDisabledFeatures(IEnumerable<string> features, ActionExecutingContext context)
        {
            if (features.Contains(FeatureFlags.Bar))
            {
                context.Result = new NotFoundResult();
            }

            return Task.CompletedTask;
        }
    }
}
