using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Virtual_Car_Show_Project.Models;

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
            return View("User_Profile_Page");
        }

        [HttpPost("register_car")]
        public IActionResult RegisterCar(Car newCar)
        {
            if (ModelState.IsValid == false)
            {
                return View("User_Profile_Page");
            }

            newCar.UserId = (int)userId;
            db.Cars.Add(newCar);
            db.SaveChanges();

            // need to go to payment page next before redirecting back to profile
            return RedirectToAction("User_Profile_Page");
            // return RedirectToAction("Occasion", new { occasionId = newOccasion.OccasionId });


        }
    }
}