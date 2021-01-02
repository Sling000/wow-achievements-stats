using Microsoft.AspNetCore.Mvc;

namespace Wow.Stats.Api.Attributes
{
    /// <summary>
    /// API version V1
    /// </summary>
    public class V1Attribute : ApiVersionAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="V1Attribute"/> class.
        /// </summary>
        public V1Attribute() : base(new ApiVersion(1, 0))
        {
        }
    }
}
