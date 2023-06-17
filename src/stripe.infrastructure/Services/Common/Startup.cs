using System;
using Microsoft.Extensions.DependencyInjection;
using stripe.shared.Common.Attributes;
using System.Reflection;
using stripe.application.Services;

namespace stripe.infrastructure.Services.Common
{
    internal static class Common
    {
        internal static void AddServices(IServiceCollection services)
        {
            var applicationAssembly = Assembly.GetAssembly(typeof(IBaseService));
            var infrastructureAssembly = Assembly.GetAssembly(typeof(Startup));

            var interfaceTypes = applicationAssembly.GetExportedTypes()
                .Where(t => t.IsInterface)
                .ToList();

            foreach (var interfaceType in interfaceTypes)
            {
                var implementationType = infrastructureAssembly.GetExportedTypes()
                    .FirstOrDefault(t => t.IsClass && interfaceType.IsAssignableFrom(t));

                if (implementationType != null)
                {
                    var lifetimeAttribute = implementationType.GetCustomAttribute<LifetimeAttribute>();
                    var lifetime = lifetimeAttribute?.Lifetime ?? ServiceLifetime.Transient;

                    services.AddService(interfaceType, implementationType, lifetime);
                }
            }
        }

        private static void AddService(this IServiceCollection services, Type serviceType, Type implementationType, ServiceLifetime lifetime)
        {
            switch (lifetime)
            {
                case ServiceLifetime.Transient:
                    services.AddTransient(serviceType, implementationType);
                    break;
                case ServiceLifetime.Scoped:
                    services.AddScoped(serviceType, implementationType);
                    break;
                case ServiceLifetime.Singleton:
                    services.AddSingleton(serviceType, implementationType);
                    break;
                default:
                    throw new ArgumentException("Invalid lifetime", nameof(lifetime));
            }
        }
    }
}

