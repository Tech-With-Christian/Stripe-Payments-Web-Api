using System;
namespace stripe.shared.DTOs.Stripe.Payments
{
    public record StripePaymentDto(
        string CustomerId,
        string ReceiptEmail,
        string Description,
        string Currency,
        long Amount);
}

