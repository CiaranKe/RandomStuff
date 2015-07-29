using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCFromScratch.Controllers
{
    public class PageCacheController : Controller
    {
        //
        // GET: /PageCache/

        [OutputCache(Duration=10, VaryByParam="none")]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Test()
        {
           return RedirectToAction("Index");
        }
    }
}
