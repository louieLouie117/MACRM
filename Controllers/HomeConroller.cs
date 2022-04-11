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


    }



}