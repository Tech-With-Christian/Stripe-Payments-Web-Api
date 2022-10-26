using System;
using Stripe_Payments_Web_Api.Models.Stripe;

namespace Stripe_Payments_Web_Api.Contracts
{
	public interface IStripeAppService
	{
		Task<StripeCustomer> AddStripeCustomerAsync(AddStripeCustomer customer, CancellationToken ct);
		Task<StripePayment> AddStripePaymentAsync(AddStripePayment payment, CancellationToken ct);
	}
}

