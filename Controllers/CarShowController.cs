using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Virtual_Car_Show_Project.Models;

namespace Virtual_Car_Show_Project.Controllers
{
    public class CarShowController : Controller
    {
        private MyContext db;
        public CarShowController(MyContext context)
        {
        db = context;
        }

        // gets userId
        private int? userId { get { return HttpContext.Session.GetInt32("userId"); } }

        // gets boolean if user is logged in or not
        private bool isLoggedIn { get { return userId != null; } }

        [HttpGet("new_car_show")]
        public IActionResult New_Car_Show()
        {
            if (isLoggedIn == false)
            {
                return RedirectToAction("LoginRegister", "LoginReg");
            }

            return View("New_Car_Show");
        }

        [HttpPost("new_car_show/create")]
        public IActionResult Create_Car_Show(CarShow newCarShow)
        {
            if (ModelState.IsValid == false)
            {
                return View("New_Car_Show");
            }

            newCarShow.UserId = (int)userId;
            db.CarShows.Add(newCarShow);
            db.SaveChanges();

            HttpContext.Session.SetString("CarShowTitle", newCarShow.Title);

            return RedirectToAction("Index", "Home");
        }

        private string CarShowTitle { get { return HttpContext.Session.GetString("CarShowTitle"); } }

        [HttpGet("{CarShowTitle}")]
        public IActionResult Car_Show()
        {
            return View("Car_Show_Page");
        }

        [HttpGet("{CarShowTitle}/rules")]
        public IActionResult Rules()
        {
            return View("Rules");
        }

        [HttpGet("{CarShowTitle}/raffles")]
        public IActionResult Raffles()
        {
            return View("Raffles");
        }
    }
}
