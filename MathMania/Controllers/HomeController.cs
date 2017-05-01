using MathMania.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MathMania.Controllers
{
    public class HomeController : Controller
    {
        private OurDbContext db = new OurDbContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Welcome()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Register()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginVm visitors)
        {


            if (string.IsNullOrEmpty(visitors.UserName) || string.IsNullOrEmpty(visitors.Password)) //check on Null
            {
                ViewBag.Error = "Please put User Name and password"; // Show Error Message
                return View(); // return to Login Page
            }
            else
            {
                if (db.Users.Any(m => m.UserName == visitors.UserName && m.Password == visitors.Password))  //Find UserName and password in database and compare it
                {
                    Session["name"] = visitors.UserName;
                    return View("Welcome"); // if database has user it return welcome page
                }


            }
            ViewBag.Error = "User Name is not found or password doesn't match"; // Show Error Message
            return View(); // return to Login Page

        }
        public ActionResult Addition()
        {
            return View();
        }
    }
}