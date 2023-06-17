using System;
namespace stripe.domain.Models.Stripe.Payments
{
    public class StripePayment
    {
        public StripePayment(string customerId, string receiptEmail, string description, string currency, long amount)
        {
            CustomerId = customerId;
            ReceiptEmail = receiptEmail;
            Description = description;
            Currency = currency;
            Amount = amount;
        }

        public string CustomerId { get; private set; } = string.Empty;
        public string ReceiptEmail { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;
        public string Currency { get; private set; } = "USD"; // Default currency
        public long Amount { get; private set; } = 0; // Default amount for charge
    }
}

