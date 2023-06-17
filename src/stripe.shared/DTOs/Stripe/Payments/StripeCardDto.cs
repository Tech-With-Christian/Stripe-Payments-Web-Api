using System;
namespace stripe.shared.DTOs.Stripe.Payments
{
    public record StripeCardDto(
        string Name,
        string CardNumber,
        string ExpirationYear,
        string ExpirationMonth,
        string Cvc);
}
