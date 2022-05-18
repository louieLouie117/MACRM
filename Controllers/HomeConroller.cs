using System;
using Microsoft.AspNetCore.Mvc;
using KcPilot.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

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

            var UserLoggedIn = HttpContext.Session.GetString("UserInSeesion");
            System.Console.WriteLine(UserLoggedIn);


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

            if (UserInputData.Market == null)
            {
                return Json(new { Status = "Market can not be empty!!" });

            }

            if (UserInputData.MarketCode == null)
            {
                return Json(new { Status = "MarketCode can not be empty!!" });

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
                HttpContext.Session.SetString("MarketCode", _context.Users.FirstOrDefault(i => i.UserId == UserInputData.UserId).MarketCode);

                User userInDb = _context.Users.FirstOrDefault(u => u.Email == UserInputData.Email);
                HttpContext.Session.SetString("UserInSeesion", userInDb.Role + "||" + userInDb.FirstName + "." + userInDb.LastName);


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
                HttpContext.Session.SetString("UserInSeesion", userInDb.Role + "||" + userInDb.FirstName + "." + userInDb.LastName);
                HttpContext.Session.SetString("MarketCode", userInDb.MarketCode);

                System.Console.WriteLine(userInDb.Role + "||" + userInDb.FirstName + "." + userInDb.LastName);

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
        public JsonResult DataGeneratorMethod(Job UserInputData)

        {
            System.Console.WriteLine("You have reached the back end of DataGenerator Method");

            Random rnd = new Random();
            DateTime datetoday = DateTime.Now;
            int rndYear = rnd.Next(datetoday.Year, datetoday.Year);
            int rndMonth = rnd.Next(datetoday.Month, datetoday.Month);
            int rndDay = rnd.Next(datetoday.Day, 31);
            DateTime generateDate = new DateTime(rndYear, rndMonth, rndDay);
            Console.WriteLine(generateDate);
            UserInputData.AppointmentDay = generateDate;

            int UserIdInSession = (int)HttpContext.Session.GetInt32("UserId");
            UserInputData.UserId = UserIdInSession;


            if (UserInputData.Rework == null)
            {
                UserInputData.Rework = "";

            }

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
            List<Job> ApiGeneratorItems = _context.Jobs
            .Where(mc => mc.JobStatus == "unassigned").ToList();


            return Json(new { Result = ApiGeneratorItems });

        }

        [HttpGet("UnassignedMethod")]
        public JsonResult UnassignedMethod(Job UserInputData)

        {
            System.Console.WriteLine("You have reached the back end of DataGenerator Method");

            string UserMarketCodeInSession = HttpContext.Session.GetString("MarketCode");

            List<Job> UnassignedList = _context.Jobs
            .Where(ua => ua.JobStatus == "unassigned")
            .Where(um => um.MarketCode == UserMarketCodeInSession)
            .ToList();


            return Json(new { Result = UnassignedList });



        }

        [HttpPost("PreScreenJobSelectedMethod")]
        public JsonResult PreScreenJobSelectedMethod(Job UserInputData)
        {

            HttpContext.Session.SetInt32("PreScreenJobSelectedInSession", UserInputData.JobStatusId);

            System.Console.WriteLine($"You have reach the backend of JobSelected!! {UserInputData.JobStatusId}");


            return Json(new { Status = true });


        }


        [HttpPost("CardJobSelectedMethod")]
        public JsonResult CardJobSelectedMethod(Job UserInputData)
        {

            HttpContext.Session.SetInt32("CardJobSelectedInSession", UserInputData.JobStatusId);
            System.Console.WriteLine($"You have reach the backend of CardJobSelected!! {UserInputData.JobStatusId}");

            return Json(new { Status = true });


        }


        [HttpPost("PreScreenJobMethod")]
        public JsonResult PreScreenJobMethod(Job UserInputData)

        {


            int UserIdInSession = (int)HttpContext.Session.GetInt32("UserId");
            UserInputData.UserId = UserIdInSession;

            var UserMarketCodeInSession = HttpContext.Session.GetString("MarketCode");
            int PreScreenJobInSession = (int)HttpContext.Session.GetInt32("PreScreenJobSelectedInSession");

            System.Console.WriteLine("You have reached the back end of PreScreenJobMethod");
            System.Console.WriteLine($"User in session: {UserIdInSession}");

            System.Console.WriteLine($"Job status: {UserInputData.JobStatus}");
            System.Console.WriteLine($"Job Color: {UserInputData.JobStatusColor}");
            System.Console.WriteLine($"Market in session: {UserMarketCodeInSession}");
            System.Console.WriteLine($"job in session: {PreScreenJobInSession}");

            Job GetJob = _context.Jobs.SingleOrDefault(id => id.JobStatusId == PreScreenJobInSession);


            // GetJob.UserId = UserIdInSession;
            GetJob.JobStatusId = PreScreenJobInSession;
            GetJob.JobStatus = UserInputData.JobStatus;
            GetJob.JobStatusColor = UserInputData.JobStatusColor;


            // _context.Update(Entry);
            _context.SaveChanges();

            List<Job> JobList = _context.Jobs
            .Where(ul => ul.MarketCode == UserMarketCodeInSession)
            .ToList();
            return Json(new { Result = "success" });

        }


        [HttpGet("AllJobListMethod")]

        public JsonResult AllJobListMethod(Job UserInputData)

        {

            int UserIdInSession = (int)HttpContext.Session.GetInt32("UserId");
            UserInputData.UserId = UserIdInSession;

            var UserMarketCodeInSession = HttpContext.Session.GetString("MarketCode");

            System.Console.WriteLine(UserMarketCodeInSession);


            System.Console.WriteLine("You have reached the back end of AllJobListMethod");
            List<Job> JobList = _context.Jobs
            .Where(um => um.MarketCode == UserMarketCodeInSession)
            .ToList();


            return Json(new { Result = JobList });

        }



        [HttpPost("RoleMethod")]

        public JsonResult RoleMethod(Role UserInputData)
        {
            System.Console.WriteLine("You have reached the backend of role");
            return Json(new { Result = true });


        }


        [HttpPost("JobCommentMethod")]

        public JsonResult JobCommentMethod(JobComment UserInputData)
        {
            System.Console.WriteLine("You have reached the backend of JobComments");
            System.Console.WriteLine(UserInputData.Notes);


            int CardJobInSession = (int)HttpContext.Session.GetInt32("CardJobSelectedInSession");
            System.Console.WriteLine($"This is the card id in session: {CardJobInSession}");

            var UserAddingNotes = HttpContext.Session.GetString("UserInSeesion");
            System.Console.WriteLine($"This is the user leaving notes: {UserAddingNotes}");


            return Json(new { Result = true });


        }




    }
}
