

using System;
using System.Linq;
using System.Web.Mvc;
using MathMania.Models;
using System.Data.SqlClient;
using MathMania.Data;
using System.Transactions;

namespace MathMania.Controllers
{
    public class RegisterController : Controller
    {
        private OurDbContext db = new OurDbContext();
        // GET: Account
        public ActionResult Index()
        {
            
                return View();
            
        }
        [HttpGet]
        //Login
        //[HttpGet]
        //public ActionResult Login()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult Login(LoginVm users)
        //{


        //    if (string.IsNullOrEmpty(users.UserName) || string.IsNullOrEmpty(users.Password)) //check on Null
        //    {
        //        ViewBag.Error = "Please put User Name and password"; // Show Error Message
        //        return View(); // return to Login Page
        //    }
        //    else
        //    {
        //        if (db.UsersAccount.Any(m => m.UserName == users.UserName && m.Password == users.Password))  //Find UserName and password in database and compare it
        //        {
        //            Session["name"] = users.UserName;
        //            return View("Index"); // if database has user it return welcome page
        //        }


        //    }
        //    ViewBag.Error = "User Name is not found or password doesn't match"; // Show Error Message
        //    return View(); // return to Login Page

        //}

        public ActionResult LoggedIn()
        {
            if (Session["UserId"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
 
        }
    }



}