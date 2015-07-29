using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Xml.Linq;

namespace FreeFormStuff
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection conn = new SqlConnection(@"Data source =.;Database=Northwind; Integrated Security=true;");
            conn.Open();
            SqlDataAdapter reader = new SqlDataAdapter("select * from products", conn);
            DataSet ds = new DataSet();
            reader.Fill(ds, "Product");

            XDocument xd = XDocument.Parse(ds.GetXml().ToString());
            //Console.WriteLine(xd);


            var q = from p in xd.Descendants("Product")
                    where (decimal)p.Element("UnitPrice") > 10m  
                    orderby p.Value ascending
                    select p;

            foreach (var name in q)
            {
                Console.WriteLine(name.Element("ProductName").Value, name.Element("UnitPrice").Value);
            }
        }
    }
}
