using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Braintree;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using SendGrid;
using StopWatcher.Data;
using StopWatcher.Models;

namespace StopWatcher.Controllers
{
    public class CheckoutController : Controller
    {
        private ApplicationDbContext _context;
        private UserManager<User> _userManager;
        private IEmailSender _emailSender;
        private Braintree.IBraintreeGateway _braintreeGateway;

        public CheckoutController(ApplicationDbContext context, UserManager<User> userManager
        , IEmailSender emailSender, Braintree.IBraintreeGateway braintreeGateway)
        {
            this._context = context;
            this._userManager = userManager;
            this._emailSender = emailSender;
            this._braintreeGateway = braintreeGateway;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["clientToken"] = await _braintreeGateway.ClientToken.GenerateAsync();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CheckoutViewModel model, string braintreeNonce)
        {
            ViewData["clientToken"] = await _braintreeGateway.ClientToken.GenerateAsync();
            if (string.IsNullOrEmpty(braintreeNonce))
            {
                this.ModelState.AddModelError("nonce", "We're unable to validate this credit card");
            }


            var message = new SendGrid.Helpers.Mail.SendGridMessage
            {
                From = new SendGrid.Helpers.Mail.EmailAddress(
                    "orders@stopwatcher.io",
                    "No-Reply"),
                //Subject = "Receipt for order #" + order.ID,
                HtmlContent = "Thanks for your order!"
            };
            message.AddTo(model.ContactEmail);

            await _emailSender.SendEmailAsync(model.ContactEmail, "Receipt for order #", "Thanks for your order!"); ;


            return RedirectToAction("index", "receipt");
        }
    }
}