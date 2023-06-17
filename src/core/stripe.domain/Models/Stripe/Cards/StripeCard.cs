using System;
namespace stripe.domain.Models.Stripe.Cards
{
    public class StripeCard
    {
        public StripeCard()
        {
            Name = string.Empty;
            CardNumber = string.Empty;
            ExpirationYear = string.Empty;
            ExpirationMonth = string.Empty;
            Cvc = string.Empty;
        }

        public StripeCard(string name, string cardNumber, string expirationYear, string expirationMonth, string cvc)
        {
            Name = name;
            CardNumber = cardNumber;
            ExpirationYear = expirationYear;
            ExpirationMonth = expirationMonth;
            Cvc = cvc;
        }

        public string Name { get; private set; }

        public string CardNumber { get; private set; }

        public string ExpirationYear { get; private set; }

        public string ExpirationMonth { get; private set; }

        public string Cvc { get; private set; }
    }
}

