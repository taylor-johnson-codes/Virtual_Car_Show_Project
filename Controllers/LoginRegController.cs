using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Virtual_Car_Show_Project.Models;

namespace Virtual_Car_Show_Project.Controllers
{
    public class LoginRegController : Controller
    {
        private MyContext db;
        public LoginRegController(MyContext context)
        {
        db = context;
        }

        [HttpGet("login_register")]
        public IActionResult LoginRegister()
        {
            return View("Login_Reg_Page");
        }

        [HttpPost("register")]
        public IActionResult Register(User newUser)
        {
            if(ModelState.IsValid)
            {
                if(db.Users.Any(u => u.Email == newUser.Email))
                {
                    ModelState.AddModelError("Email", "Email already registered!");
                }
            }

            if(ModelState.IsValid == false)
            {
                return View("Login_Reg_Page");
            }

            PasswordHasher<User> hasher = new PasswordHasher<User>();
            newUser.Password = hasher.HashPassword(newUser, newUser.Password);

            db.Users.Add(newUser);
            db.SaveChanges();
            
            HttpContext.Session.SetInt32("userId", newUser.UserId);
            HttpContext.Session.SetString("userName", newUser.FirstName);
            return RedirectToAction("User_Profile_Page");
        }

        [HttpPost("login")]
        public IActionResult Login(LoginUser loginUser)
        {
            string genericErrorMsg = "Invalid email or password!";

            if(ModelState.IsValid == false)
            {
                return View("Login_Reg_Page");
            }

            User dbUser = db.Users.FirstOrDefault(u => u.Email == loginUser.LoginEmail);

            if(dbUser == null)
            {
                ModelState.AddModelError("LoginEmail", genericErrorMsg);
                return View("Login_Reg_Page");
            }

            PasswordHasher<LoginUser> hasher = new PasswordHasher<LoginUser>();
            PasswordVerificationResult pwCompareResult = hasher.VerifyHashedPassword(loginUser, dbUser.Password, loginUser.LoginPassword);
            
            if(pwCompareResult == 0)
            {
                ModelState.AddModelError("LoginEmail", genericErrorMsg);
                return View("Login_Reg_Page");
            }

            HttpContext.Session.SetInt32("userId", dbUser.UserId);
            HttpContext.Session.SetString("userName", dbUser.FirstName);
            return RedirectToAction("User_Profile_Page");
        }

        [HttpGet("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login_Reg_Page");
        }
    }
}