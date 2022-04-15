using System;
using Microsoft.AspNetCore.Mvc;
using KcPilot.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

namespace KcPilot.Controllers
{

    public class HomeController : Controller
    {
        private MyContext _context;
        public HomeController(MyContext context)
        {
            _context = context;
        }


        [HttpGet("")]
        public IActionResult index()
        {
            return View("index");
        }


        [HttpGet("Dashboard")]
        public IActionResult Dashboard()
        {
            if (HttpContext.Session.GetInt32("UserId") == null)
            {
                return RedirectToAction("index");
            }
            int UserIdInSession = (int)HttpContext.Session.GetInt32("UserId");
            User UserIndb = _context.Users
                .FirstOrDefault(u => u.UserId == UserIdInSession);

            DashboardWrapper wMod = new DashboardWrapper();
            wMod.User = UserIndb;


            return View("Dashboard", wMod);
        }




        [HttpPost("RegisterNewUserMethod")]
        public JsonResult RegisterNewUserMethod(User UserInputData)
        {
            DashboardWrapper wMod = new DashboardWrapper();
            System.Console.WriteLine("you reach the backend to register a new user!!");
            if (_context.Users.Any(u => u.Email == UserInputData.Email))
            {
                ModelState.AddModelError("Email", "Email already in use!");
                return Json(new { Status = "Email already in use!" });

            }

            if (UserInputData.Email == null)
            {
                return Json(new { Status = "Email can not be empty!" });

            }

            if (UserInputData.Password == null)
            {
                return Json(new { Status = "Password can not be empty!" });

            }

            if (UserInputData.Password != UserInputData.ConfirmPassword)
            {
                return Json(new { Status = "Password do not match!" });

            }


            if (_context.Users.Any(u => u.Email == UserInputData.Email))
            {
                return Json(new { Status = "Email already in use!" });

            }
            else
            {


                // Must have "using Microsoft.AspNetCore.Identity;"
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                UserInputData.Password = Hasher.HashPassword(UserInputData, UserInputData.Password);
                UserInputData.AccountStatus = AccountStatus.Active;
                UserInputData.OnlineStatus = OnlineStatus.Active;
                UserInputData.PhoneNumber = "615-123-4455";
                UserInputData.ProfilePhoto = "placeholder.png";
                UserInputData.AppVersion = "1.0";
                UserInputData.Extention = "none";
                _context.Add(UserInputData);
                _context.SaveChanges();

                // Session needs to be after both _context
                HttpContext.Session.SetInt32("UserId", _context.Users.FirstOrDefault(i => i.UserId == UserInputData.UserId).UserId);
                Console.WriteLine("You may contine!");

                return Json(new { Status = "User Registered!!" });
            }


        }


        [HttpPost("LoginMethod")]

        public JsonResult LoginMethod(Login UserInputData)
        {
            DashboardWrapper wMod = new DashboardWrapper();

            System.Console.WriteLine("you reach the backend of sign in!!");


            if (ModelState.IsValid)
            {
                User userInDb = _context.Users.FirstOrDefault(u => u.Email == UserInputData.Email);



                if (userInDb == null)
                {
                    Console.WriteLine($"email error");
                    ModelState.AddModelError("Email", "Invalid Email/Password");
                    return Json(new { Status = "email error" });


                }
                var hasher = new PasswordHasher<Login>();
                var result = hasher.VerifyHashedPassword(UserInputData, userInDb.Password, UserInputData.Password);
                if (result == 0)
                {
                    // Still need these for debugging? Console.Writelines should be removed
                    // something else should happer here besides a WriteLine
                    Console.WriteLine("Pasword Error");
                    return Json(new { Status = "password error" });


                }

                HttpContext.Session.SetInt32("UserId", userInDb.UserId);
                return Json(new { Status = "Logged in successfully!" });


            }

            Console.WriteLine("No access");
            return Json(new { Status = false });


        }


        [HttpGet("SendToDashboard")]
        public IActionResult SendToDashboard()
        {

            return RedirectToAction("dashboard");
        }


        [HttpPost("DataGeneratorMethod")]
        public JsonResult DataGeneratorMethod(ApiGenerator UserInputData)

        {


            System.Console.WriteLine("You have reached the back end of DataGenerator Method");
            int UserIdInSession = (int)HttpContext.Session.GetInt32("UserId");

            UserInputData.UserId = UserIdInSession;

            //  var Entry = new ApiGenerator
            // {
            //     UserId = UserIdInSession,
            //     StartDate = FromForm.StartDate,
            //     StartTime = FromForm.StartTime,
            //     EndTime = FromForm.EndTime,
            //     Description = FromForm.Description,
            //     StreetNumber = FromForm.StreetNumber,
            //     StreetName = FromForm.StreetName,
            //     City = FromForm.City,
            //     State = FromForm.State,
            //     Zipcode = FromForm.Zipcode,
            //     County = FromForm.County,
            //     Image = "placeholder.png"
            // };

            //  System.Console.WriteLine($"Entry to be send to db {Entry}");




            _context.Add(UserInputData);
            _context.SaveChanges();

            return Json(new { Result = UserInputData });

        }





    }
}
