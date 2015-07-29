using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC3Person.Controllers
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
        public ActionResult Index(WebbyStuff.Models.Person p)
        {
            if (ModelState.IsValid)
            {
                return View("Display", p);
            }
            return View();
        }

        public ActionResult Display(WebbyStuff.Models.Person p)
        {
            return View();
        }
    }
}
