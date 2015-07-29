using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebServices.Models
{
    public class WSController : Controller
    {
        //
        // GET: /WS/

        public ActionResult Index()
        {
            localhost.HelloService oSVC = new localhost.HelloService();
            ViewData["message"] = oSVC.HelloWorld();
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Index(int a, int b)
        {
            localhost.HelloService oSVC = new localhost.HelloService();
            ViewData["message"] = oSVC.addTwoNumbers(a, b);
            return View();
        }

        public ActionResult Products()
        {
            localhost1.Products oSVS = new localhost1.Products();
            ViewData["ProductsXML"] = oSVS.getAvailibleProductsXML();
            return View();
        }

        public ActionResult InvokeTest()
        {
            localhost.HelloService oSVC = new localhost.HelloService();
            localhost.Test o = oSVC.ReturnTest();
            ViewData["one"] = o.A;
            ViewData["two"] = o.B;
            return View();
        }

        public ActionResult BuyNow()
        {
            localhost.HelloService x = new localhost.HelloService();
            x.MakeOrder("BOTTM", 3);
            return View();
        }

    }
}
