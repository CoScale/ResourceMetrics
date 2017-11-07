using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using System;

namespace App.Metrics.AspNetCore.Resource
{
    /// <summary>
    /// Inserts the Resource metrics at the beginning of the pipeline.
    /// </summary>
    public class DefaultResourceMetricsStartupFilter : IStartupFilter
    {
        /// <inheritdoc />
        public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
        {
            return AddResourceMetricsMiddleware;

            void AddResourceMetricsMiddleware(IApplicationBuilder builder)
            {
                builder.UseAllResourceMetricsMiddleware();

                next(builder);
            }
        }
    }
}
