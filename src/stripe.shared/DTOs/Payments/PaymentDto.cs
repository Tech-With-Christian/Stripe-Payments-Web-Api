using System;
namespace stripe.shared.DTOs.Payments
{
    public record PaymentDto(
        string CustomerId,
        string ReceiptEmail,
        string Description,
        string Currency,
        long Amount,
        string PaymentId);
}
