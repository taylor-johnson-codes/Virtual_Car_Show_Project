using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stripe;
using Virtual_Car_Show_Project.Models;

namespace Virtual_Car_Show_Project.Controllers
{
    public class HomeController : Controller
    {
        private MyContext db;
        public HomeController(MyContext context)
        {
        db = context;
        }

        [HttpGet("")]
        public IActionResult HomePage()
        {
            List<CarShow> carshows = db.CarShows
                .Include(cs => cs.CarShowCreator)
                .Include(cs => cs.RegisteredCars)
                .OrderBy(cs => cs.StartDateAndTime)
                .ToList();
            return View("HomePage", carshows);
        }

        [HttpPost("/charge")]
        public IActionResult Charge(string StripeEamail, string StripeToken)
        {
            var customerService = new CustomerService();
            var chargeService = new ChargeService();

            var customer = customerService.Create(new CustomerCreateOptions {
                Email = StripeEamail,
                Source = StripeToken,
                
            });

            var charge = chargeService.Create(new ChargeCreateOptions {
                Amount = 500,
                Description = "Sample Charge",
                Currency = "usd",
                Customer = customer.Id
            });

            return View("Success");
        }
    }
}
