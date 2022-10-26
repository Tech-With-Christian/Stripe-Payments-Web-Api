using System;
namespace Stripe_Payments_Web_Api.Models.Stripe
{
	public record AddStripeCard(
		string Name,
		string CardNumber,
		string ExpirationYear,
		string ExpirationMonth,
		string Cvc);
}

