using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using stripe.application.Services.Stripe;
using stripe.domain.Models.Stripe.Customers;
using stripe.domain.Models.Stripe.Payments;
using stripe.shared.Common.Attributes;
using Stripe;

namespace stripe.infrastructure.Services.Stripe
{
    [LifetimeAttribute(ServiceLifetime.Scoped)]
    public class StripeService : IStripeService
    {
        private readonly ChargeService _chargeService;
        private readonly CustomerService _customerService;
        private readonly TokenService _tokenService;
        private readonly ILogger<StripeService> _logger;

        public StripeService(ChargeService chargeService, CustomerService customerService, TokenService tokenService, ILogger<StripeService> logger)
        {
            _chargeService = chargeService;
            _customerService = customerService;
            _tokenService = tokenService;
            _logger = logger;
        }

        /// <summary>
        /// Create a new customer at Stripe through API using customer and card details from records.
        /// </summary>
        /// <param name="customer">Stripe Customer</param>
        /// <param name="ct">Cancellation Token</param>
        /// <returns>Stripe Customer</returns>
        public async Task<string> CreateStripeCustomerAsync(StripeCustomer customer, CancellationToken ct)
        {
            // Set Stripe Token options based on customer data
            TokenCreateOptions tokenOptions = new TokenCreateOptions
            {
                Card = new TokenCardOptions
                {
                    Name = customer.Name,
                    Number = customer.CreditCard.CardNumber,
                    ExpYear = customer.CreditCard.ExpirationYear,
                    ExpMonth = customer.CreditCard.ExpirationMonth,
                    Cvc = customer.CreditCard.Cvc
                }
            };

            // Create new Stripe Token
            Token stripeToken = await _tokenService.CreateAsync(tokenOptions, null, ct);

            // Set Customer options using
            CustomerCreateOptions customerOptions = new CustomerCreateOptions
            {
                Name = customer.Name,
                Email = customer.Email,
                Source = stripeToken.Id
            };

            // Create customer at Stripe
            Customer createdCustomer = await _customerService.CreateAsync(customerOptions, cancellationToken: ct);

            // Return the created customer at stripe
            return createdCustomer.Id;
        }

        /// <summary>
        /// Add a new payment/charge at Stripe using Customer and Payment details.
        /// Customer have to exist at Stripe already.
        /// </summary>
        /// <param name="payment">Stripe Payment</param>
        /// <param name="ct">Cancellation Token</param>
        /// <returns><Stripe Payment/returns>
        public async Task<string> CreateStripePaymentAsync(StripePayment payment, CancellationToken ct)
        {
            Customer chargeCustomer = await _customerService.GetAsync(payment.CustomerId, cancellationToken: ct);

            ChargeDestinationOptions chargeDestinationOptions = new ChargeDestinationOptions
            {
                Amount = payment.Amount
            };

            // Set the options for the payment we would like to create at Stripe
            ChargeCreateOptions chargeOptions = new ChargeCreateOptions
            {
                Customer = payment.CustomerId,
                ReceiptEmail = payment.ReceiptEmail,
                Description = payment.Description,
                Currency = payment.Currency,
                Amount = payment.Amount,
                Destination = chargeDestinationOptions
            };

            // Create the payment
            Charge chargedPayment = await _chargeService.CreateAsync(chargeOptions, cancellationToken: ct);

            // Return the payment to requesting method
            return chargedPayment.Id;
        }
    }
}

