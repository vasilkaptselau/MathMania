﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MathMania.Models;

namespace MathMania.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            using (OurDbContext db = new OurDbContext())
            {
                return View();
            }
        }
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserAccount account)
        {
            if (ModelState.IsValid)
            {
                using (OurDbContext db = new OurDbContext())
                {
                    db.UserAccount.Add(account);
                    db.SaveChanges();

                }
                ModelState.Clear();
                ViewBag.Message = account.FirstName + " " + account.LastName + " successfully registered.";
            }
            return View();
        }
        //Login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(UserAccount user)
        {
            using (OurDbContext db = new OurDbContext())
            {
                var usr = db.UserAccount.Single(u => u.UserName == user.UserName && u.Password == user.Password);
                if(user != null)
                {
                    Session["UserID"] = usr.UserID.ToString();
                    Session["Username"] = usr.UserName.ToString();
                    return RedirectToAction("LoggedIn");
                }
                else
                {
                    ModelState.AddModelError("", "Username or Password is wrong.");
                }
            }
            return View();
        }

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