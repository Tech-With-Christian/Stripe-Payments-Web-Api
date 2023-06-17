using System;
using stripe.application.Services.Common;
using stripe.domain.Models.Stripe.Customers;
using stripe.domain.Models.Stripe.Payments;

namespace stripe.application.Services.Stripe
{
    public interface IStripeService : IScopedService
    {
        Task<string> CreateStripeCustomerAsync(StripeCustomer customer, CancellationToken ct);
        Task<string> CreateStripePaymentAsync(StripePayment payment, CancellationToken ct);
    }
}

