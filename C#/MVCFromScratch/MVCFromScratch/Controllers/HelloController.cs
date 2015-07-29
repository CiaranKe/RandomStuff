using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCFromScratch.Controllers
{
    public class HelloController : Controller
    {
        //
        // GET: /Hello/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult World()
        {
            return View("MyWorld");
        }

        public ActionResult There()
        {
            return View();
        }
    }
}
