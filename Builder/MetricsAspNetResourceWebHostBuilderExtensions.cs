using App.Metrics.AspNetCore.Resource;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

// ReSharper disable CheckNamespace
namespace Microsoft.AspNetCore.Hosting
// ReSharper restore CheckNamespace
{
    public static class MetricsAspNetResourceWebHostBuilderExtensions
    {
        /// <summary>
        ///     Adds App Metrics services, configuration and middleware to the
        ///     <see cref="T:Microsoft.AspNetCore.Hosting.IWebHostBuilder" />.
        /// </summary>
        /// <param name="hostBuilder">The <see cref="T:Microsoft.AspNetCore.Hosting.IWebHostBuilder" />.</param>
        /// <returns>A reference to this instance after the operation has completed.</returns>
        /// <exception cref="ArgumentNullException">
        ///     <see cref="T:Microsoft.AspNetCore.Hosting.IWebHostBuilder" /> cannot be null
        /// </exception>
        public static IWebHostBuilder UseResourceMetrics(this IWebHostBuilder hostBuilder)
        {
            hostBuilder.ConfigureMetrics();

            hostBuilder.ConfigureServices(
                (context, services) =>
                {
                    services.AddResourceMetricsMiddleware(context.Configuration);
                    services.AddSingleton<IStartupFilter>(new DefaultResourceMetricsStartupFilter());
                });

            return hostBuilder;
        }

        /// <summary>
        ///     Adds App Metrics services, configuration and middleware to the
        ///     <see cref="T:Microsoft.AspNetCore.Hosting.IWebHostBuilder" />.
        /// </summary>
        /// <param name="hostBuilder">The <see cref="T:Microsoft.AspNetCore.Hosting.IWebHostBuilder" />.</param>
        /// <param name="optionsDelegate">A callback to configure <see cref="ResourceMetricsOptions" />.</param>
        /// <returns>A reference to this instance after the operation has completed.</returns>
        /// <exception cref="ArgumentNullException">
        ///     <see cref="T:Microsoft.AspNetCore.Hosting.IWebHostBuilder" /> cannot be null
        /// </exception>
        public static IWebHostBuilder UseResourceMetrics(
            this IWebHostBuilder hostBuilder,
            Action<ResourceMetricsOptions> optionsDelegate)
        {
            hostBuilder.ConfigureMetrics();

            hostBuilder.ConfigureServices(
                (context, services) =>
                {
                    services.AddResourceMetricsMiddleware(optionsDelegate, context.Configuration);
                    services.AddSingleton<IStartupFilter>(new DefaultResourceMetricsStartupFilter());
                });

            return hostBuilder;
        }

        /// <summary>
        ///     Adds App Metrics services, configuration and middleware to the
        ///     <see cref="T:Microsoft.AspNetCore.Hosting.IWebHostBuilder" />.
        /// </summary>
        /// <param name="hostBuilder">The <see cref="T:Microsoft.AspNetCore.Hosting.IWebHostBuilder" />.</param>
        /// <param name="setupDelegate">A callback to configure <see cref="ResourceMetricsOptions" />.</param>
        /// <returns>A reference to this instance after the operation has completed.</returns>
        /// <exception cref="ArgumentNullException">
        ///     <see cref="T:Microsoft.AspNetCore.Hosting.IWebHostBuilder" /> cannot be null
        /// </exception>
        public static IWebHostBuilder UseResourceMetrics(
            this IWebHostBuilder hostBuilder,
            Action<WebHostBuilderContext, ResourceMetricsOptions> setupDelegate)
        {
            hostBuilder.ConfigureMetrics();

            hostBuilder.ConfigureServices(
                (context, services) =>
                {
                    var ResourceOptions = new ResourceMetricsOptions();
                    services.AddResourceMetricsMiddleware(
                        options => setupDelegate(context, ResourceOptions),
                        context.Configuration);
                    services.AddSingleton<IStartupFilter>(new DefaultResourceMetricsStartupFilter());
                });

            return hostBuilder;
        }

        /// <summary>
        ///     Adds App Metrics services, configuration and middleware to the
        ///     <see cref="T:Microsoft.AspNetCore.Hosting.IWebHostBuilder" />.
        /// </summary>
        /// <param name="hostBuilder">The <see cref="T:Microsoft.AspNetCore.Hosting.IWebHostBuilder" />.</param>
        /// <param name="configuration">The <see cref="IConfiguration"/> containing <see cref="ResourceMetricsOptions"/></param>
        /// <param name="optionsDelegate">A callback to configure <see cref="ResourceMetricsOptions" />.</param>
        /// <returns>A reference to this instance after the operation has completed.</returns>
        /// <exception cref="ArgumentNullException">
        ///     <see cref="T:Microsoft.AspNetCore.Hosting.IWebHostBuilder" /> cannot be null
        /// </exception>
        public static IWebHostBuilder UseResourceMetrics(
            this IWebHostBuilder hostBuilder,
            IConfiguration configuration,
            Action<ResourceMetricsOptions> optionsDelegate)
        {
            hostBuilder.ConfigureMetrics();

            hostBuilder.ConfigureServices(
                services =>
                {
                    services.AddResourceMetricsMiddleware(optionsDelegate, configuration);
                    services.AddSingleton<IStartupFilter>(new DefaultResourceMetricsStartupFilter());
                });

            return hostBuilder;
        }
    }
}
