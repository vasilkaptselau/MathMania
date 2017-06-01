using MathMania.Data;
using MathMania.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
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
                using (MathManiaDataContext context = new MathManiaDataContext())
                {
                   int count =  context.Accounts.Where(m => m.UserName == users.UserName && m.Password == users.Password).Count();
                    if(count == 0)
                    {
                        ModelState.AddModelError("", "Account does not exists. Register");
                        return View(users);
                    }

                    return RedirectToAction("Welcome");

                }
            }
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

                using (MathManiaDataContext context = new MathManiaDataContext())
                {

                    try
                    {
                        int count = context.Accounts.Where(m => m.UserName.ToLower() == model.UserName).Count();

                        if (count == 0)
                        {
                            using (TransactionScope transaction = new TransactionScope())
                            {
                                Data.Account account = new Data.Account();
                                account.UserName = model.UserName;
                                account.FirstName = model.FirstName;
                                account.LastName = model.LastName;
                                account.Password = model.Password;
                                account.TeacherName = model.TeacherName;

                                context.Accounts.InsertOnSubmit(account);

                                context.SubmitChanges();
                                transaction.Complete();
                                return RedirectToAction("Welcome");
                            }

                        }
                        else
                        {
                            ModelState.AddModelError("", "UserName already exists, Please login");
                        }
                        return View(model);
                    }
                    catch (Exception)
                    {
                    }
                }

            }

            return View(model);
        }


        public ActionResult Addition()
        {
         
            return View();

        }
    }
}