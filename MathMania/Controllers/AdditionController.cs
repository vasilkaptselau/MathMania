using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MathMania.Models;

namespace MathMania.Controllers
{


    public class AdditionController : Controller
    {

        public ActionResult Index()
        {

            return View();
        }

        [HttpPost]

        public ActionResult Addition(AdditionVm model)
        {
            model.sum = model.addend1 + model.addend2;
            return View(model);
        }
    }
}