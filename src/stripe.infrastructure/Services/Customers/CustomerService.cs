using System;
using Microsoft.Extensions.DependencyInjection;
using stripe.application.Services.Customers;
using stripe.domain.Models.Customers;
using stripe.shared.Common.Attributes;

namespace stripe.infrastructure.Services.Customers
{
    [LifetimeAttribute(ServiceLifetime.Transient)]
    public class CustomerService : ICustomerService
    {
        public CustomerService()
        {
        }

        public Task<Customer> CreateCustomerAsync(Customer customer)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteCustomerAsync(Guid customerId)
        {
            throw new NotImplementedException();
        }

        public Task<Customer> GetCustomerByIdAsync(Guid customerId)
        {
            throw new NotImplementedException();
        }

        public Task<Customer> GetCustomerByStripeIdAsync(string stripeId)
        {
            throw new NotImplementedException();
        }

        public Task<Customer> UpdateCustomerAsync(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}

