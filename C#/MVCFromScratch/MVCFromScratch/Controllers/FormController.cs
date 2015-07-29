using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCFromScratch.Controllers
{
    public class FormController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Index(PersonInfoForm model)
        {
            String interests = " ";

            ViewData["fname"] = model.Firstname;
            ViewData["lname"] = model.LastName;
            ViewData["Gender"] = model.Gender;
            ViewData["Salutation"] = model.Salutation; 

            if (model.Interests != null)
            {
                foreach (String s in model.Interests)
                {
                    interests +=" " + s;
                }
                ViewData["Interests"] = interests;
            }
            else
            {
                ViewData["Interests"] = "none";
            }
            return View();
        }
    }
}
