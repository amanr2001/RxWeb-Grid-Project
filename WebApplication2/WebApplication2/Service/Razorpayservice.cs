using Microsoft.AspNetCore.Mvc;
using Razorpay.Api;
using System.Net;
using System.Security.Cryptography;
using System.Text;

using WebApplication2.Dto;
using WebApplication2.Models;

namespace WebApplication2.Service
{
    public class Razorpayservice
    {

        private readonly string keyId = "rzp_test_A5ZSz6riT6Yh0l";
        private readonly string keySecret = "OH1axejjA5HZ2jYYnJhP2XT4";
        private RazorpayClient client;

        public Razorpayservice()
        {
            this.client = new RazorpayClient(keyId, keySecret);
        }

        public string CreateOrder(decimal amount, string currency, string receipt)
        {
            var options = new Dictionary<string, object>
        {
            { "amount", amount * 100 },  // Convert to paise 
            { "currency", currency },
            { "receipt", receipt },
        };

            var order = client.Order.Create(options);
            return order.ToString();
        }

        public Task<paymentresponseDTO> VerifyPaymentSignature(string paymentId)
        {
            
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            Razorpay.Api.RazorpayClient client = new Razorpay.Api.RazorpayClient("rzp_test_A5ZSz6riT6Yh0l", "OH1axejjA5HZ2jYYnJhP2XT4");
            Razorpay.Api.Payment payment =client.Payment.Fetch(paymentId);
            // This code is for capture the payment 
            Dictionary<string, object> options = new Dictionary<string, object>();
            options.Add("amount", payment.Attributes["amount"]);
            Razorpay.Api.Payment paymentCaptured = payment.Capture(options);
            string amt = paymentCaptured.Attributes["amount"];
            var response = new paymentresponseDTO
            {
                Status = paymentCaptured.Attributes["status"],
                paymentId = paymentId,
                paymentmethod = paymentCaptured.Attributes["method"],
                time = DateTime.Now,
                amount = (paymentCaptured.Attributes["amount"])/100
            };
            return Task.FromResult(response);

        }

       
    }
}
