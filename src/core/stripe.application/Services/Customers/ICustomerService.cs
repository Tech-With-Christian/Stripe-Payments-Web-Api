using System;
using stripe.application.Services.Common;
using stripe.domain.Models.Customers;

namespace stripe.application.Services.Customers
{
    public interface ICustomerService : ITransientService
    {
        Task<Customer> GetCustomerByIdAsync(Guid customerId);
        Task<Customer> GetCustomerByStripeIdAsync(string stripeId);
        Task<Customer> CreateCustomerAsync(Customer customer);
        Task<Customer> UpdateCustomerAsync(Customer customer);
        Task<bool> DeleteCustomerAsync(Guid customerId);
    }
}

