using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC3WebbyStuff.Models;
using MVC3WebbyStuff.localhost;

namespace MVC3WebbyStuff.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
        public ActionResult EmpList()
        {

            localhost.MVC3WebbyStuff eMP = new localhost.MVC3WebbyStuff();
            MVC3WebbyStuff.Models.Employee[] empL = eMP.getAllEmployees();
            return View(empL);
        }

        public ActionResult MgrList()
        {

            localhost.MVC3WebbyStuff eMP = new localhost.MVC3WebbyStuff();
            Manager[] empL = eMP.getAllManagers();
            return View(empL);
        }

        public ActionResult SlsList()
        {

            localhost.MVC3WebbyStuff eMP = new localhost.MVC3WebbyStuff();
            SalesEmployee[] empL = eMP.getAllSales();
            return View(empL);
        }

        public ActionResult getEmp(int id)
        {
            localhost.MVC3WebbyStuff eMP = new localhost.MVC3WebbyStuff();
            MVC3WebbyStuff.Models.Employee empL = eMP.getEmployeesByID(id);
            ViewData["Name"] = empL.Name;
            ViewData["ID"] = empL.Number;
            ViewData["Salary"] = empL.Salary;
            ViewData["Dept"] = empL.Department;

            return View();
        }


        public ActionResult search()
        {
            return View();
        }

        public ActionResult getEmpByDept(String dept)
        {
            localhost.MVC3WebbyStuff eMP = new localhost.MVC3WebbyStuff();
            Employee[] empL = eMP.getEmployeesByDept(dept);
            return View(empL);
        }

        public ActionResult Department()
        {
            localhost.MVC3WebbyStuff eMP = new localhost.MVC3WebbyStuff();
            String[] depts = eMP.getDepartments();
            return View(depts);
        }

        public ActionResult Add()
        {
            return View();
        }

        public ActionResult AddMgr()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AddMgr(String Name, double Salary, String Dept, int Reports, double BonPerRept)
        {
            localhost.MVC3WebbyStuff eMP = new localhost.MVC3WebbyStuff();
            int ID = eMP.AddEmployee(Name, Salary, Dept);
            eMP.AddManager(ID, Reports, BonPerRept);
            return RedirectToAction("getEmp", new { id = ID });
        }


        public ActionResult AddSls()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AddSls(String Name, double Salary, String Dept, double Comission, double ComissionRate, int numSales)
        {
            localhost.MVC3WebbyStuff eMP = new localhost.MVC3WebbyStuff();
            int ID = eMP.AddEmployee(Name, Salary, Dept);
            eMP.AddSalesEmp(ID, Comission, ComissionRate, numSales);
            return RedirectToAction("getEmp", new { id = ID });
        }

        public ActionResult AddEmp()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AddEmp(String Name, double Salary, String Dept)
        {
            localhost.MVC3WebbyStuff eMP = new localhost.MVC3WebbyStuff();
            int ID = eMP.AddEmployee(Name, Salary, Dept);
            return RedirectToAction("getEmp", new { id = ID });
        }
    }
}
