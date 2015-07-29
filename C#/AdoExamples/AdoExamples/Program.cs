using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdoExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            //getXML();
            //DBConnect();
            //SqlCommandBrokenDown();
            Exercise();
        }

        private static void Exercise()
        {
            SqlConnection conn = new SqlConnection(@"Data source =.;Database=AdventureWorks; Integrated Security=true;");
            conn.Open();
            SqlCommand cmd = new SqlCommand("select distinct Production.ProductCategory.Name As \"Category\" FROM  Production.ProductCategory order by category", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            Console.WriteLine("Please Select a category From the list: ");
            while (dr.Read())
            {
                Console.WriteLine("{0}", dr["category"]);
            }
            Console.Write("Selection: ");
            string category = Console.ReadLine();
            dr.Close();

            cmd.CommandText = "select ProductCategoryID FROM Production.ProductCategory where Name = '" + category + "'";
            dr = cmd.ExecuteReader();
            dr.Read();
            int x = (int) dr["ProductCategoryID"];
            dr.Close();


            cmd.CommandText = "select Name  FROM Production.ProductSubCategory where ProductCategoryID = '" + x + "'";
            dr = cmd.ExecuteReader();
            Console.WriteLine("Please Select a subcategory From the list: ");
            while (dr.Read())
            {
                Console.WriteLine("{0}", dr["Name"]);
            }
            Console.Write("Selection: ");
            string subcategory = Console.ReadLine();
            dr.Close();

            cmd.CommandText = "select ProductSubCategoryID FROM Production.ProductSubCategory where Name = '" + subcategory + "'";
            dr = cmd.ExecuteReader();
            dr.Read();
            int y = (int)dr["ProductSubCategoryID"];
            dr.Close();

            cmd.CommandText = "select name, listprice FROM Production.Product where ProductSubCategoryID = '" + y + "'";
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Console.WriteLine("{0}", dr["Name"], dr["ListPrice"]);
            }
            
            /*cmd.CommandText = "Select Production.ProductSubcategory.Name As \"Subcat\" FROM  Production.ProductSubcategory where ProductCategoryID = '" + category + "'";
            dr = cmd.ExecuteReader();
            Console.WriteLine("Please Select a sub-category From the list: ");
            while (dr.Read())
            {
                Console.WriteLine("{0}", dr["Subcat"]);
            }
            Console.Write("Selection: ");
            */
        }

        private static void DBConnect()
        {
            SqlConnection conn = new SqlConnection(@"Data source =.;Database=Northwind; Integrated Security=true;");
            conn.Open();

            SqlCommand cmd = new SqlCommand("select productName, unitPrice from products", conn);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Console.WriteLine("{0} costs {1}", dr["productname"], dr["unitprice"]);
            }
            conn.Close();
        }
        private static void SqlCommandBrokenDown()
        {
            SqlConnection conn = new SqlConnection(@"Data source =.;Database=Northwind; Integrated Security=true;");
            conn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "getOrdersForCustomer";
            cmd.Parameters.Add(new SqlParameter("@CustomerID", SqlDbType.NChar, 5));
            cmd.Parameters["@CustomerID"].Value = "ALFKI";
            SqlDataReader dr = cmd.ExecuteReader();

            Console.WriteLine("Products ordered by ALFKI");
            while (dr.Read())
            {
                Console.WriteLine("\t{0}", dr["productname"]);
            }
            conn.Close();
        }

        private static void getXML()
        {
            string conn = @"Data source =.;Database=Northwind; Integrated Security=true;";
            SqlDataAdapter sda = new SqlDataAdapter("AllProducts", conn);
            DataSet ds = new DataSet();
            sda.Fill(ds, "ProductList");
            Console.WriteLine(ds.GetXml());
        }
    }
}
