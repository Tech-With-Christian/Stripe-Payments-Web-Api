using System;
namespace Stripe_Payments_Web_Api.Models.Stripe
{
	public record StripePayment(
        string CustomerId,
        string ReceiptEmail,
        string Description,
        string Currency,
        long Amount,
        string PaymentId);
}

