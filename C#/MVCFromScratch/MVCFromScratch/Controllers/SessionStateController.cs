using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCFromScratch.Controllers
{
    public class SessionStateController : Controller
    {
        //
        // GET: /SessionState/

        public ActionResult Index()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Index(String SessionInput)
        {
            Session["SampleText"] = SessionInput;
            return View();
        }

    }
}
