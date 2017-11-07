using Microsoft.Extensions.Options;

namespace App.Metrics.AspNetCore.Resource.Internal
{
    /// <summary>
    ///     Sets up default Resource metrics middleware options for <see cref="ResourceMetricsOptions"/>.
    /// </summary>
    public class ResourceMetricsMiddlewareOptionsSetup : IConfigureOptions<ResourceMetricsOptions>
    {
        /// <inheritdoc />
        public void Configure(ResourceMetricsOptions options)
        {
        }
    }
}
