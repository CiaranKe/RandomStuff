using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC3Person.Controllers;
using MVC3Person.Models;

namespace WebbyStuff.Controllers
{
    public class PersonController : Controller
    {
        //
        // GET: /Person/

        public ActionResult Index()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Index(Person p)
        {
            if (ModelState.IsValid)
            {
                return View("Display", p);
            }
            return View();
        }

        public ActionResult Display(Person p)
        {
            return View();
        }
    }
}
