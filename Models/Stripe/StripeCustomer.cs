using System;
namespace Stripe_Payments_Web_Api.Models.Stripe
{
	public record StripeCustomer(
		string Name,
		string Email,
		string CustomerId);
}

