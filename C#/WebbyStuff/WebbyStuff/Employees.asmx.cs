using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using WebbyStuff.Models;
using System.Data.SqlClient;

namespace WebbyStuff
{
    /// <summary>
    /// Summary description for Employees
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Employees : System.Web.Services.WebService
    {

        [WebMethod]
        public List<WebbyStuff.Models.Employee> getAllEmployees()
        {
            List<Employee> emp = new List<WebbyStuff.Models.Employee>();
            SqlConnection conn = new SqlConnection(@"Data Source = .; Database=AdventureWorks; Integrated Security=true;");
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT ID, Name, Salary, Department from Employee Where ID not in (SELECT ID from Manager UNION SELECT ID from SalesEmployee)", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                emp.Add(new WebbyStuff.Models.Employee((int)dr["ID"], (double)dr["Salary"], (String)dr["Name"], (String)dr["Department"]));
            }

            return emp;
        }

        [WebMethod]
        public List<WebbyStuff.Models.Manager> getAllManagers()
        {
            List<Manager> emp = new List<WebbyStuff.Models.Manager>();
            SqlConnection conn = new SqlConnection(@"Data Source = .; Database=AdventureWorks; Integrated Security=true;");
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT E.ID, E.Name, E.Salary, E.Department, M.Reports, M.BonusPerReport  from Employee AS E Join Manager as M on M.ID = E.ID", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                emp.Add(new WebbyStuff.Models.Manager((int)dr["ID"], (double)dr["Salary"], (String)dr["Name"], (String)dr["Department"],(int)dr["Reports"], (double)dr["BonusPerReport"]));
            }

            return emp;
        }

        [WebMethod]
        public List<WebbyStuff.Models.SalesEmployee> getAllSales()
        {
            List<WebbyStuff.Models.SalesEmployee> emp = new List<WebbyStuff.Models.SalesEmployee>();
            SqlConnection conn = new SqlConnection(@"Data Source = .; Database=AdventureWorks; Integrated Security=true;");
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT E.ID, E.Name, E.Salary, E.Department, S.ComissionRate, S.NumOfSales  from Employee AS E Join SalesEmployee as S on S.ID = E.ID", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                emp.Add(new WebbyStuff.Models.SalesEmployee((int)dr["ID"], (double)dr["Salary"], (String)dr["Name"], (String)dr["Department"], (double)dr["ComissionRate"], (int)dr["NumOfSales"]));
            }

            return emp;
        }


        [WebMethod]
        public List<WebbyStuff.Models.Employee> getEmployeesByDept(string dept)
        {
            List<Employee> emp = new List<WebbyStuff.Models.Employee>();
            SqlConnection conn = new SqlConnection(@"Data Source = .; Database=AdventureWorks; Integrated Security=true;");
            conn.Open();
            SqlCommand cmd = new SqlCommand("select ID, Salary, Name, Department from dbo.Employee where Department = '" + dept + "'", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                emp.Add(new Employee((int)dr["ID"], (double)dr["Salary"], (String)dr["Name"], (String)dr["Department"]));
            } 
            return emp;
        }

        [WebMethod]
        public WebbyStuff.Models.Employee getEmployeesByID(int ID)
        {
            Employee emp = new Employee();
            SqlConnection conn = new SqlConnection(@"Data Source = .; Database=AdventureWorks; Integrated Security=true;");
            conn.Open();
            SqlCommand cmd = new SqlCommand("select ID, Salary, Name, Department from dbo.Employee where ID = '" + ID + "'", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                emp = new WebbyStuff.Models.Employee((int)dr["ID"], (double)dr["Salary"], (String)dr["Name"], (String)dr["Department"]);
            }
            return emp;
        }

        [WebMethod]
        public int AddEmployee(String Name, double Salary, String Dept)
        {
            SqlConnection conn = new SqlConnection(@"Data Source = .; Database=AdventureWorks; Integrated Security=true;");
            conn.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Employee(Name, Salary, Department) VALUES ('" + Name + "'," + "'" + Salary + "'," + "'" + Dept + "')", conn);
            cmd.ExecuteNonQuery();

            SqlCommand cmd2 = new SqlCommand("select ID from Employee where Name = '" + Name + "' and  Salary = '" + Salary + "' and Department = '" + Dept + "'", conn);
            SqlDataReader dr = cmd2.ExecuteReader();
            if (dr.Read())
            {
                return (int)dr["ID"];
            }
            return 0;
        }

        [WebMethod]
        public void AddManager(int ID, int Reports, double BonPerRept)
        {
            SqlConnection conn = new SqlConnection(@"Data Source = .; Database=AdventureWorks; Integrated Security=true;");
            conn.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Manager(ID, Reports, BonusPerReport) VALUES ('" + ID + "'," + "'" + Reports + "'," + "'" + BonPerRept + "')", conn);
            cmd.ExecuteNonQuery();
        }

        [WebMethod]
        public void AddSalesEmp(int ID, double Comission, double ComissionRate, int numSales)
        {
            SqlConnection conn = new SqlConnection(@"Data Source = .; Database=AdventureWorks; Integrated Security=true;");
            conn.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO SalesEmployee(ID, ComissionRate, NumOfSales, Comission) VALUES ('" + ID + "'," + "'" + ComissionRate + "'," + "'" + numSales + "'," + "'" + Comission +"')", conn);
            cmd.ExecuteNonQuery();
        }

        [WebMethod]
        public List<String> getDepartments()
        {
            List<String> depts = new List<string>();
            SqlConnection conn = new SqlConnection(@"Data Source = .; Database=AdventureWorks; Integrated Security=true;");
            conn.Open();
            SqlCommand cmd = new SqlCommand("select distinct Department from Employee", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                depts.Add((String)dr["Department"]);
            }
            return depts;
        }

    }
}
