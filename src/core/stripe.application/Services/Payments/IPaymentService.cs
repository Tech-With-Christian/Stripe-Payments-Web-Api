using System;
using stripe.domain.Models.Payments;

namespace stripe.application.Services.Payments
{
    public interface IPaymentService : IBaseService
    {
        Task<Payment> GetPaymentByIdAsync(Guid paymentId);
        Task<Payment> GetPaymentByStripeIdAsync(string stripePaymentId);
        Task<List<Payment>> GetPaymentsByCustomerId(Guid customerId);
        Task<List<Payment>> GetPaymentsByStripeCustomerId(string stripeCutomerId);
    }
}

