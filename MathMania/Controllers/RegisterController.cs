
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MathMania.Models;
using MathMania.Data;
using System.Data.SqlClient;
using static MathMania.Data.MathManiaDatabase;
using System.Configuration;
using MathMania.Data.MathManiaDatabaseTableAdapters;

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
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(RegisterVm model)
        {
            if (ModelState.IsValid)   // validate all values and save in one bucket
            {
                try
                {
                    RegistrationTableAdapter adapter = new RegistrationTableAdapter();
                    var data =  adapter.GetData();

                    try
                    {
                        var result = data.Where(m => m.UserName.ToLower() == model.UserName).Single();
                        
                    }
                    catch (Exception)
                    {
                        // does not exxists
                        adapter.Insert(model.FirstName, model.LastName, model.UserName, model.Password);
                    }

                }
                catch (SqlException ex)
                {

                }

                return RedirectToAction("Index"); //redirect to passwords generator
            }

            return View();
        }
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