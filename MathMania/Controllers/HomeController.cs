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
            return View(db.UsersAccount);
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginVm users)
        {


            if (string.IsNullOrEmpty(users.UserName) || string.IsNullOrEmpty(users.Password)) //check on Null
            {
                ViewBag.Error = "Please put User Name and password"; // Show Error Message
                return View(); // return to Login Page
            }
            else
            {
                if (db.UsersAccount.Any(m => m.UserName == users.UserName && m.Password == users.Password))  //Find UserName and password in database and compare it
                {
                    Session["name"] = users.UserName;
                    return View("RegIndex"); // if database has user it return welcome page
                }


            }
            ViewBag.Error = "User Name is not found or password doesn't match"; // Show Error Message
            return View(); // return to Login Page

        }
        public ActionResult Welcome()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpGet]
        public ActionResult StudentsLocker()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }
        //[HttpPost]
        //public ActionResult Register(UserAccount)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        using (OurDbContext db = new OurDbContext())
        //        {
        //            db.UsersAccount.Add(UserAccount);
        //            db.SaveChanges();
        //        }
        //        ModelState.Clear();
        //        ViewBag.Message = UserAccount.FirstName + " " + acocunt.Lastname + "Successfully Registered";
        //    }
        //    return View();
        //}


        public ActionResult Addition()
        {
         
            return View();

        }
    }
}