using Microsoft.Extensions.Configuration;
using Stripe;
using Stripe.Checkout;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlatformApi.Services.Implementation
{
    public class StripeService
    {
        private readonly IConfiguration _configuration;

        public StripeService(IConfiguration configuration)
        {
            _configuration = configuration;
            StripeConfiguration.ApiKey = _configuration["Stripe:SecretKey"];
        }

        public async Task<Session> CreateCheckoutSession(decimal planPaiementPrix, string currency)
        {
            var domain = _configuration["Stripe:Domain"];
            var options = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string> { "card" },
                LineItems = new List<SessionLineItemOptions>
                {
                    new SessionLineItemOptions
                    {
                        PriceData = new SessionLineItemPriceDataOptions
                        {
                            UnitAmount = (long)(planPaiementPrix * 100),
                            Currency = currency,
                            ProductData = new SessionLineItemPriceDataProductDataOptions
                            {
                                Name = "Paiement",
                            },
                        },
                        Quantity = 1,
                    },
                },
                Mode = "payment",
                SuccessUrl = $"{domain}/success",
                CancelUrl = $"{domain}/cancel",
            };

            var service = new SessionService();
            return await service.CreateAsync(options);
        }
    }
}
