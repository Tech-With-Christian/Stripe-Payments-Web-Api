using System;
using stripe.application.Services.Customers;
using stripe.domain.Models.Customers;

namespace stripe.infrastructure.Services.Customers
{
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

