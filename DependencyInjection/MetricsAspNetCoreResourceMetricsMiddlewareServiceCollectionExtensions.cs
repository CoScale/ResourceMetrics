using App.Metrics.AspNetCore.Resource;
using App.Metrics.AspNetCore.Resource.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using System;

// ReSharper disable CheckNamespace
namespace Microsoft.Extensions.DependencyInjection
// ReSharper restore CheckNamespace
{
    public static class MetricsAspNetCoreResourceMetricsMiddlewareServiceCollectionExtensions
    {
        private static readonly string DefaultConfigSection = nameof(ResourceMetricsOptions);

        /// <summary>
        ///     Adds App Metrics AspNet Core Resource metrics middleware services to the specified <see cref="IServiceCollection" />.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection" /> to add services to.</param>
        /// <returns>
        ///     An <see cref="IServiceCollection" /> that can be used to further configure services.
        /// </returns>
        public static IServiceCollection AddResourceMetricsMiddleware(this IServiceCollection services)
        {
            AddResourceMetricsMiddlewareServices(services);

            return services;
        }

        /// <summary>
        ///     Adds App Metrics AspNet Core Resource metrics middleware services to the specified <see cref="IServiceCollection" />.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection" /> to add services to.</param>
        /// <param name="configuration">The <see cref="IConfiguration" /> from where to load <see cref="ResourceMetricsOptions" />.</param>
        /// <returns>
        ///     An <see cref="IServiceCollection" /> that can be used to further configure services.
        /// </returns>
        public static IServiceCollection AddResourceMetricsMiddleware(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddResourceMetricsMiddleware(configuration.GetSection(DefaultConfigSection));

            return services;
        }

        /// <summary>
        ///     Adds App Metrics AspNet Core Resource metrics middleware services to the specified <see cref="IServiceCollection" />.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection" /> to add services to.</param>
        /// <param name="configuration">The <see cref="IConfigurationSection" /> from where to load <see cref="ResourceMetricsOptions" />.</param>
        /// <returns>
        ///     An <see cref="IServiceCollection" /> that can be used to further configure services.
        /// </returns>
        public static IServiceCollection AddResourceMetricsMiddleware(
            this IServiceCollection services,
            IConfigurationSection configuration)
        {
            services.AddResourceMetricsMiddleware();

            services.Configure<ResourceMetricsOptions>(configuration);

            return services;
        }

        /// <summary>
        ///     Adds App Metrics AspNet Core  Resource metrics middleware services to the specified <see cref="IServiceCollection" />.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection" /> to add services to.</param>
        /// <param name="configuration">The <see cref="IConfiguration" /> from where to load <see cref="ResourceMetricsOptions" />.</param>
        /// <param name="setupAction">
        ///     An <see cref="Action{ResourceMetricsOptions}" /> to configure the provided <see cref="ResourceMetricsOptions" />.
        /// </param>
        /// <returns>
        ///     An <see cref="IServiceCollection" /> that can be used to further configure services.
        /// </returns>
        public static IServiceCollection AddResourceMetricsMiddleware(
            this IServiceCollection services,
            IConfiguration configuration,
            Action<ResourceMetricsOptions> setupAction)
        {
            services.AddResourceMetricsMiddleware(configuration.GetSection(DefaultConfigSection), setupAction);

            return services;
        }

        /// <summary>
        ///     Adds App Metrics AspNet Core Resource metrics middleware services to the specified <see cref="IServiceCollection" />.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection" /> to add services to.</param>
        /// <param name="configuration">The <see cref="IConfigurationSection" /> from where to load <see cref="ResourceMetricsOptions" />.</param>
        /// <param name="setupAction">
        ///     An <see cref="Action{MetricsWebTrackingOptions}" /> to configure the provided <see cref="ResourceMetricsOptions" />.
        /// </param>
        /// <returns>
        ///     An <see cref="IServiceCollection" /> that can be used to further configure services.
        /// </returns>
        public static IServiceCollection AddResourceMetricsMiddleware(
            this IServiceCollection services,
            IConfigurationSection configuration,
            Action<ResourceMetricsOptions> setupAction)
        {
            services.AddResourceMetricsMiddleware();

            services.Configure<ResourceMetricsOptions>(configuration);
            services.Configure(setupAction);

            return services;
        }

        /// <summary>
        ///     Adds App Metrics AspNet Core Resource metrics middleware services to the specified <see cref="IServiceCollection" />.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection" /> to add services to.</param>
        /// <param name="setupAction">
        ///     An <see cref="Action{MetricsAspNetCoreOptions}" /> to configure the provided <see cref="ResourceMetricsOptions" />.
        /// </param>
        /// <param name="configuration">The <see cref="IConfiguration" /> from where to load <see cref="ResourceMetricsOptions" />.</param>
        /// <returns>
        ///     An <see cref="IServiceCollection" /> that can be used to further configure services.
        /// </returns>
        public static IServiceCollection AddResourceMetricsMiddleware(
            this IServiceCollection services,
            Action<ResourceMetricsOptions> setupAction,
            IConfiguration configuration)
        {
            services.AddResourceMetricsMiddleware(setupAction, configuration.GetSection(DefaultConfigSection));

            return services;
        }

        /// <summary>
        ///     Adds App Metrics AspNet Core Resource metrics middleware services to the specified <see cref="IServiceCollection" />.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection" /> to add services to.</param>
        /// <param name="setupAction">
        ///     An <see cref="Action{MetricsAspNetCoreOptions}" /> to configure the provided <see cref="ResourceMetricsOptions" />.
        /// </param>
        /// <param name="configuration">The <see cref="IConfigurationSection" /> from where to load <see cref="ResourceMetricsOptions" />.</param>
        /// <returns>
        ///     An <see cref="IServiceCollection" /> that can be used to further configure services.
        /// </returns>
        public static IServiceCollection AddResourceMetricsMiddleware(
            this IServiceCollection services,
            Action<ResourceMetricsOptions> setupAction,
            IConfigurationSection configuration)
        {
            services.AddResourceMetricsMiddleware();

            services.Configure(setupAction);
            services.Configure<ResourceMetricsOptions>(configuration);

            return services;
        }

        /// <summary>
        ///     Adds App Metrics AspNet Core Resource metrics middleware services to the specified <see cref="IServiceCollection" />.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection" /> to add services to.</param>
        /// <param name="setupAction">
        ///     An <see cref="Action{MetricsAspNetCoreOptions}" /> to configure the provided <see cref="ResourceMetricsOptions" />.
        /// </param>
        /// <returns>
        ///     An <see cref="IServiceCollection" /> that can be used to further configure services.
        /// </returns>
        public static IServiceCollection AddResourceMetricsMiddleware(
            this IServiceCollection services,
            Action<ResourceMetricsOptions> setupAction)
        {
            services.AddResourceMetricsMiddleware();

            services.Configure(setupAction);

            return services;
        }

        internal static void AddResourceMetricsMiddlewareServices(IServiceCollection services)
        {
            //
            // Options
            //
            var descriptor = ServiceDescriptor.Singleton<IConfigureOptions<ResourceMetricsOptions>, ResourceMetricsMiddlewareOptionsSetup>();
            services.TryAddEnumerable(descriptor);
        }
    }
}
