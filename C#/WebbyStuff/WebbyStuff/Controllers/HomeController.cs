using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebbyStuff.Models;
using System.Collections;

namespace WebbyStuff.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult EmpList()
        {

            localhost.Employees eMP = new localhost.Employees();
            WebbyStuff.localhost.Employee[] empL = eMP.getAllEmployees();
            return View(empL);
        }

        public ActionResult MgrList()
        {

            localhost.Employees eMP = new localhost.Employees();
            WebbyStuff.localhost.Manager[] empL = eMP.getAllManagers();
            return View(empL);
        }

        public ActionResult SlsList()
        {

            localhost.Employees eMP = new localhost.Employees();
            WebbyStuff.localhost.SalesEmployee[] empL = eMP.getAllSales();
            return View(empL);
        }

        public ActionResult getEmp(int id)
        {
            localhost.Employees eMP = new localhost.Employees();
            WebbyStuff.localhost.Employee empL = eMP.getEmployeesByID(id);
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
            localhost.Employees eMP = new localhost.Employees();
            WebbyStuff.localhost.Employee[] empL = eMP.getEmployeesByDept(dept);
            return View(empL);
        }

        public ActionResult Department()
        {
            localhost.Employees eMP = new localhost.Employees();
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
            localhost.Employees eMP = new localhost.Employees();
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
            localhost.Employees eMP = new localhost.Employees();
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
            localhost.Employees eMP = new localhost.Employees();
            int ID = eMP.AddEmployee(Name, Salary, Dept);
            return RedirectToAction("getEmp", new { id = ID });
        }
    }
}
