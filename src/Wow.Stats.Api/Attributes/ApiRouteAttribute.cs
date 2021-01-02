using System;
using Microsoft.AspNetCore.Mvc;

namespace Wow.Stats.Api.Attributes
{
    /// <summary>
    /// Attribute for default api routing rules
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.RouteAttribute" />
    [AttributeUsage(AttributeTargets.Class)]
    public class ApiRouteAttribute : RouteAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Attribute"></see> class.
        /// </summary>
        /// <returns>ApiRouteAttribute.</returns>
        public ApiRouteAttribute()
            : base("v{version:apiVersion}/[controller]/[action]")
        {
        }
    }

}
