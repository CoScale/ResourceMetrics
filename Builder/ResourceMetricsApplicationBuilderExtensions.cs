using App.Metrics;
using App.Metrics.AspNetCore.Resource;
using App.Metrics.AspNetCore.Resource.Middleware;
using App.Metrics.Extensions.DependencyInjection.Internal;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

// ReSharper disable CheckNamespace
namespace Microsoft.AspNetCore.Builder
// ReSharper restore CheckNamespace
{
    /// <summary>
    ///     Extension methods for <see cref="IApplicationBuilder" /> to add App Metrics Middleware to the request execution
    ///     pipeline which measure typical web metrics.
    /// </summary>
    public static class ResourceMetricsApplicationBuilderExtensions
    {
        /// <summary>
        ///     Adds Resource metrics to the <see cref="IApplicationBuilder" /> request execution pipeline.
        /// </summary>
        /// <param name="app">The <see cref="IApplicationBuilder" />.</param>
        /// <returns>A reference to this instance after the operation has completed.</returns>
        public static IApplicationBuilder UseAllResourceMetricsMiddleware(this IApplicationBuilder app)
        {
            EnsureRequiredServices(app);

            app.UseResourceMetricsMiddleware();

            return app;
        }

        /// <summary>
        ///     Adds Resource metrics to the <see cref="IApplicationBuilder" /> request execution pipeline.
        /// </summary>
        /// <param name="app">The <see cref="IApplicationBuilder" />.</param>
        /// <returns>A reference to this instance after the operation has completed.</returns>
        public static IApplicationBuilder UseResourceMetricsMiddleware(this IApplicationBuilder app)
        {
            EnsureRequiredServices(app);

            var metricsOptions = app.ApplicationServices.GetRequiredService<MetricsOptions>();
            var ResourceMiddlwareOptionsAccessor = app.ApplicationServices.GetRequiredService<IOptions<ResourceMetricsOptions>>();

            UseMetricsMiddleware<ResourceMiddleware>(app, metricsOptions, ResourceMiddlwareOptionsAccessor);

            return app;
        }
        private static void EnsureRequiredServices(IApplicationBuilder app)
        {
            // Verify if AddMetrics was done before calling UseMetricsAllMiddleware
            // We use the MetricsMarkerService to make sure if all the services were added.
            AppMetricsServicesHelper.ThrowIfMetricsNotRegistered(app.ApplicationServices);
        }

        private static bool ShouldUseMetricsEndpoint(IOptions<ResourceMetricsOptions> ResourceMetricsOptionsAccessor,
            MetricsOptions metricsOptions,
            HttpContext context)
        {
            return metricsOptions.Enabled;
        }

        private static void UseMetricsMiddleware<TMiddleware>(
            IApplicationBuilder app,
            MetricsOptions metricsOptions,
            IOptions<ResourceMetricsOptions> ResourceMiddlwareOptionsAccessor)
        {
            app.UseWhen(
                context => ShouldUseMetricsEndpoint(ResourceMiddlwareOptionsAccessor, metricsOptions, context),
                appBuilder => { appBuilder.UseMiddleware<TMiddleware>(); });
        }
    }

}
