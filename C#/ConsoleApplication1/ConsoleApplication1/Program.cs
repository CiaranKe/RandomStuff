using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Collections;

namespace HelloWorld
{
    enum DaysOfWeek : byte
    {
        Monday = 1, Tuesday, WednesDay, Thursday, Friday, Saturday, Sunday =0
    }

    class Program
    {
        static void Main(string[] args)
        {
            
        }

        private static void UtterTrype()
        {
            List<Employee> test = new List<Employee>();
            SqlConnection conn = new SqlConnection(@"Data source =.;Database=AdventureWorks; Integrated Security=true;");
            conn.Open();
            SqlCommand cmd = new SqlCommand("exec getSalesEmployees", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {

                test.Add(new SalesEmployee((int)dr["ID"], (double)dr["Salary"], (string)dr["Name"], 1F, 1));
            }
            dr.Close();
            cmd = new SqlCommand("exec getManagers", conn);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {

                test.Add(new Manager((int)dr["ID"], (double)dr["Salary"], (string)dr["Name"], (int)dr["BonusPerReport"], (float)dr["Reports"]));
            }
            dr.Close();

            foreach (SalesEmployee x in test)
            {
                x.printPay();
            }
        }

        public void PolyPay(IPrintData p)
        {
            p.print();
        }

        private static void InheratanceTest()
        {
            Manager emp = new Manager();
            emp.Name = "A. Underhill";
            emp.Number = 50;
            emp.Salary = 21000.0F;
            emp.Reports = 3;
            emp.BonusPerReport = 1000.0F;
        }

        private static void EnumDisplay()
        {
            DaysOfWeek dl = DaysOfWeek.Tuesday;
            Console.Write("Day: {0}\n", (int)dl);
        }

        private static void GetPrintName()
        {
            Console.WriteLine("Enter Your name");
            string strName = Console.ReadLine();
            string strCRLF = "\r\n";
            string strHello = "Hello";
            Console.Write("{0} {1} {2}", strHello, strName, strCRLF);
        }

        public static void TestGC()
        {
            //Employee emp = new Employee(23, 0.0f, "M. Taylor");
            System.GC.Collect(); //Garbage never collected while waiting for console input.
        }

        public static void ado()
        {
            string conn = @"Data source =.;Database=Northwind; Integrated Security=true;";
            SqlDataAdapter sda = new SqlDataAdapter("Select * from products", conn);
            DataSet ds = new DataSet();
            sda.Fill(ds, "ProductList");
            Console.WriteLine(ds.GetXml());
        }
    }
}
