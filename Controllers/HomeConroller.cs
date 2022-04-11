using System;
using Microsoft.AspNetCore.Mvc;
using KcPilot.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;


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

            return Json(new { Status = "User Registered" });
        }


        [HttpPost("login")]
        public JsonResult Login(LoginUser UserInputData)
        {

            System.Console.WriteLine("you reach the backend of sign in!!");

            return Json(new { Status = "User Logged in" });


        }




    }




}