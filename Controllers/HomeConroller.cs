using System;
using Microsoft.AspNetCore.Mvc;
using KcPilot.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.AspNetCore.Identity;

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
            return View("Dashboard");
        }




        [HttpPost("RegisterNewUserMethod")]
        public JsonResult RegisterNewUserMethod(User UserInputData)
        {

            System.Console.WriteLine("you reach the backend to register a new user!!");


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

                // Still need these for debugging? Console.Writelines should be removed

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
                Console.WriteLine("You may contine!");

                return Json(new { Status = "Service Advovate Registered!!" });
            }

        }


        [HttpPost("LoginMethod")]

        public JsonResult LoginMethod(Login UserInputData)
        {

            System.Console.WriteLine("you reach the backend of sign in!!");

            return Json(new { Status = "User Logged in" });


        }




    }







}
