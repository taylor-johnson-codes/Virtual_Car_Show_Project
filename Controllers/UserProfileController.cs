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

        [HttpGet("user_profile")]
        public IActionResult UserProfilePage()
        {
            return View();
        }

        [HttpPost("submit_car")]
        public IActionResult SubmitCar(Car car)
        {
            if(ModelState.IsValid){
                Car NewCar = new Car(){
                    UserId = (int)HttpContext.Session.GetInt32("UserId"),
                    Year = car.Year,
                    Make = car.Make,
                    Model = car.Model,
                    Category = car.Category,
                    Description = car.Description
                };
                db.Cars.Add(NewCar);
                db.SaveChanges();
                return RedirectToAction("UserProfilePage");
            }
            else{
                return View("UserProfilePage");
            }
        }
    }
}