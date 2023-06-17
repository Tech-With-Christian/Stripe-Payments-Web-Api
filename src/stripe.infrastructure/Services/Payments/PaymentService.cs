using System;
using stripe.application.Services.Payments;
using stripe.domain.Models.Payments;

namespace stripe.infrastructure.Services.Payments
{
    public class PaymentService : IPaymentService
    {
        public PaymentService()
        {
        }

        public Task<Payment> GetPaymentByIdAsync(Guid paymentId)
        {
            throw new NotImplementedException();
        }

        public Task<Payment> GetPaymentByStripeIdAsync(string stripePaymentId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Payment>> GetPaymentsByCustomerId(Guid customerId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Payment>> GetPaymentsByStripeCustomerId(string stripeCutomerId)
        {
            throw new NotImplementedException();
        }
    }
}

