using System;
namespace stripe.shared.DTOs.Stripe.Payments
{
    public record StripeCustomerDto(
        string Email,
        string Name,
        string CustomerId,
        StripeCardDto CreditCard);
}
