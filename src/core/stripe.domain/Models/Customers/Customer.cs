using System;
using stripe.domain.Models.Base;
using stripe.domain.Models.Payments;

namespace stripe.domain.Models.Customers
{
    public class Customer : BaseModel
    {
        public Customer()
        {
            Name = string.Empty;
            Email = string.Empty;
            StripeCustomerId = string.Empty;
            Payments = new List<Payment>();
        }

        public Customer(string name, string email, string stripeCustomerId, List<Payment> payments)
        {
            Name = name;
            Email = email;
            StripeCustomerId = stripeCustomerId;
            Payments = payments;
        }

        public string Name { get; private set; }
        public string Email { get; private set; }
        public string StripeCustomerId { get; private set; }
        public List<Payment> Payments { get; set; } = new List<Payment>();
    }
}

