using System;
using stripe.application.Services.Common;
using Serilog;
using Microsoft.Extensions.DependencyInjection;

namespace stripe.infrastructure.Services.Common
{
    internal static class Startup
    {
        /// <summary>
        /// Add Services to DI container automatically.
        /// </summary>
        /// <param name="services">Services</param>
        /// <returns>Service collection with registered services with their respective lifetime in the service container</returns>
        internal static IServiceCollection AddCommonServices(this IServiceCollection services)
        {

            #region Transient Services

            var transientServiceType = typeof(ITransientService);

            // Get services inheriting transient service
            var transientServices = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(transientServiceType.IsAssignableFrom)
                .Where(p => p.IsClass && !p.IsAbstract)
                .Select(p => new
                {
                    Service = p.GetInterfaces().FirstOrDefault(),
                    Implementation = p
                });

            // Register each transient service for startup
            if (transientServices.Count() > 0)
            {
                Log.Information($"Registering {transientServices.Count()} Transient Service(s)");
                foreach (var transientService in transientServices)
                {
                    if (transientServiceType.IsAssignableFrom(transientService.Service))
                    {
                        services.AddTransient(transientService.Service, transientService.Implementation);
                    }
                }
            }

            #endregion

            #region Scoped Services

            var scopedServiceType = typeof(IScopedService);

            // Get services inheriting scoped service
            var scopedServices = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(scopedServiceType.IsAssignableFrom)
                .Where(p => p.IsClass && !p.IsAbstract)
                .Select(p => new
                {
                    Service = p.GetInterfaces().FirstOrDefault(),
                    Implementation = p
                });

            // Register each scoped service for startup
            if (scopedServices.Count() > 0)
            {
                Log.Information($"Registering {scopedServices.Count()} Scoped Service(s)");
            }
            foreach (var scopedService in scopedServices)
            {
                if (scopedServiceType.IsAssignableFrom(scopedService.Service))
                {
                    services.AddTransient(scopedService.Service, scopedService.Implementation);
                }
            }

            #endregion Scoped Services

            #region Singleton Services

            var singletonServiceType = typeof(ISingletonService);

            // Get services inheriting singleton service
            var singletonServices = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(singletonServiceType.IsAssignableFrom)
                .Where(p => p.IsClass && !p.IsAbstract)
                .Select(p => new
                {
                    Service = p.GetInterfaces().FirstOrDefault(),
                    Implementation = p
                });

            // Register each singleton service for startup
            if (singletonServices.Count() > 0)
            {
                Log.Information($"Registering {singletonServices.Count()} Singleton Service(s)");
            }
            foreach (var singletonService in singletonServices)
            {
                if (singletonServiceType.IsAssignableFrom(singletonService.Service))
                {
                    services.AddScoped(singletonService.Service, singletonService.Implementation);
                }
            }

            #endregion Singleton Services

            return services;

        }
    }
}

