using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace MVCFromScratch.Controllers
{
    public class DirectoryController : Controller
    {
        //
        // GET: /Directory/

        public ActionResult Index()
        {
            /*
            ViewData["title"] = "Course Directory Listing";
            ViewData["message"] = @"Listing of Directories in C:\Course";
            DirectoryInfo di = new DirectoryInfo(@"C:\Users\ciaranke\Documents\Visual Studio 2010\Projects");
            return View(di.EnumerateDirectories());
             */
            return DrillDown(@"C:\Users\ciaranke\Documents\Visual Studio 2010\Projects");
            
        }

        public ActionResult DrillDown(String dir)
        {
            ViewData["title"] = "Directory Listing";
            ViewData["message"] = @"Listing of directories in " + dir;
            DirectoryInfo di = new DirectoryInfo(dir);
            return View("Index", di.EnumerateDirectories());
        }

    }
}
