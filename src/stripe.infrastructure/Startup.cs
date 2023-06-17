using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using stripe.infrastructure.Services.Common;
using stripe.infrastructure.Services.Stripe;

namespace stripe.infrastructure
{
    public static class Startup
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // Register Services
            services.AddStripeServices(configuration);
            services.AddCommonServices();
            
            return services;
        }
    }
}

