using Microsoft.AspNetCore.Mvc;
using Wow.Stats.Api.Attributes;

namespace Wow.Stats.Api.GlobalStats.V1
{
    /// <summary>
    /// Global stats api controller
    /// </summary>
    [V1]
    [ApiRoute]
    [ApiController]
    public class GlobalStatsController : ControllerBase
    {
        /// <summary>
        /// Temporary test endpoint.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Test()
        {
            return this.NoContent();
        }
    }
}
