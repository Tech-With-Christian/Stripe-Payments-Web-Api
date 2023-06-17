using System;
using stripe.domain.Models.Base;
using stripe.domain.Models.Customers;

namespace stripe.domain.Models.Payments
{
    public class Payment : BaseModel
    {
        public Payment()
        {
            StripeCustomerId = string.Empty;
            ReceiptEmail = string.Empty;
            Description = string.Empty;
            Currency = "USD";
            Amount = 0;
            PaymentId = string.Empty;
        }

        public Payment(string stripeCustomerId, string receiptEmail, string description, string currency, long amount, string paymentId, Guid customerId)
        {
            stripeCustomerId = StripeCustomerId;
            receiptEmail = ReceiptEmail;
            description = Description;
            currency = Currency;
            amount = Amount;
            paymentId = PaymentId;
            customerId = CustomerId;
        }

        public string StripeCustomerId { get; private set; }
        public string ReceiptEmail { get; private set; }
        public string Description { get; private set; }
        public string Currency { get; private set; }
        public long Amount { get; private set; }
        public string PaymentId { get; private set; }

        // Relation
        public Customer Customer { get; set; }
        public Guid CustomerId { get; set; }
    }
}

