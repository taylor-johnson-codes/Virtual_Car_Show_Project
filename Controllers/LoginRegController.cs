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

        [HttpGet("register_login")]
        public IActionResult RegisterLogin()
        {
            return View();
        }

        [HttpPost("register")]
        public IActionResult Register(User user)
        {
            if(ModelState.IsValid){
                if(db.Users.Any(u => u.Email == user.Email)){
                    ModelState.AddModelError("Email", "Email already exists!");
                    return View("RegisterLogin");
                }
                else{
                    PasswordHasher<User> Hasher = new PasswordHasher<User>();
                    user.Password = Hasher.HashPassword(user, user.Password);
                    db.Users.Add(user);
                    db.SaveChanges();
                    User registerId = db.Users.FirstOrDefault(u => u.Email == user.Email);
                    HttpContext.Session.SetInt32("UserId", registerId.UserId);
                    return RedirectToAction("UserProfilePage", "UserProfile");
                }
            }
            else{
                return View("RegisterLogin");
            }
        }

        [HttpPost("login")]
        public IActionResult Login(LoginReg submission)
        {
            if(ModelState.IsValid){
                var userEm = db.Users.FirstOrDefault(u => u.Email == submission.Email);
                if(userEm == null){
                    ModelState.AddModelError("Email", "Invalid Email");
                    return View("RegisterLogin");
                }
                PasswordHasher<LoginReg> hasher  = new PasswordHasher<LoginReg>();
                PasswordVerificationResult result = hasher.VerifyHashedPassword(submission, userEm.Password, submission.Password);
                if(result == 0){
                    ModelState.AddModelError("Password", "Invalid Password");
                    return View("RegisterLogin");
                }
                HttpContext.Session.SetInt32("UserId", userEm.UserId);
                return RedirectToAction("UserProfilePage", "UserProfile");
            }
            else{
                return View("RegisterLogin");
            }
        }

        [HttpGet("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("RegisterLogin");
        }
    }
}