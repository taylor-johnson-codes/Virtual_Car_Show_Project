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

        [HttpGet("car_show_name")]
        public IActionResult Car_Show()
        {
            return View("Car_Show_Page");
        }

        [HttpGet("car_show_name/rules")]
        public IActionResult Rules()
        {
            return View("Rules");
        }

        [HttpGet("car_show_name/raffles")]
        public IActionResult Raffles()
        {
            return View("Raffles");
        }
    }
}
