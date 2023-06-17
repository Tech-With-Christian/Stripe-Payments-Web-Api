using System;
using stripe.domain.Models.Stripe.Cards;

namespace stripe.domain.Models.Stripe.Customers
{
    public class StripeCustomer
    {
        public StripeCustomer()
        {
            Name = string.Empty;
            Email = string.Empty;
            CreditCard = new StripeCard();
        }

        public StripeCustomer(string email, string name, StripeCard creditCard)
        {
            Email = email;
            Name = name;
            CreditCard = creditCard;
        }

        public string Email { get; private set; }
        public string Name { get; private set; }
        public StripeCard CreditCard { get; private set; }
    }
}

