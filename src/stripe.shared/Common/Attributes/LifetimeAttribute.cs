using System;
using Microsoft.Extensions.DependencyInjection;

namespace stripe.shared.Common.Attributes
{
    /// <summary>
    /// Specifies the service lifetime for a class.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class LifetimeAttribute : Attribute
    {
        /// <summary>
        /// Gets the service lifetime associated with the class.
        /// </summary>
        public ServiceLifetime Lifetime { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="LifetimeAttribute"/> class with the specified service lifetime.
        /// </summary>
        /// <param name="lifetime">The service lifetime to associate with the class.</param>
        public LifetimeAttribute(ServiceLifetime lifetime)
        {
            Lifetime = lifetime;
        }
    }
}

