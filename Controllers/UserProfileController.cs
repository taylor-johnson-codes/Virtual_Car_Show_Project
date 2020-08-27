using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Virtual_Car_Show_Project.Models;
using Stripe;

namespace Virtual_Car_Show_Project.Controllers
{
    public class UserProfileController : Controller
    {
        private MyContext db;
        public UserProfileController(MyContext context)
        {
        db = context;
        }

        // gets userId
        private int? userId { get { return HttpContext.Session.GetInt32("userId"); } }

        // gets boolean if user is logged in or not
        private bool isLoggedIn { get { return userId != null; } }

        [HttpGet("user_profile/{userId}")]
        public IActionResult ProfilePage()
        {
            if (isLoggedIn == false)
            {
                return RedirectToAction("Login_Reg_Page", "LoginReg");
            }

            return View("User_Profile_Page");
        }

        [HttpPost("register_car")]
        public IActionResult RegisterCar(Car newCar)
        {
            if (isLoggedIn == false)
            {
                return RedirectToAction("Login_Reg_Page", "LoginReg");
            }

            if (ModelState.IsValid == false)
            {
                return View("User_Profile_Page");
            }

            newCar.UserId = (int)userId;
            db.Cars.Add(newCar);
            db.SaveChanges();

            return RedirectToAction("PayFee");
        }

        [HttpPost("charge")]
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

            return View("User_Profile_Page");
        }
    }
}