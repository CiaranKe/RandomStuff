using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using WebServices.Models;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace WebServices
{
    /// <summary>
    /// Summary description for HelloService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class HelloService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public string addTwoNumbers(int ValueOne, int ValueTwo)
        {
            return (ValueOne + ValueTwo).ToString();
        }

        [WebMethod]
        public Test ReturnTest()
        {
            Test oT = new Test("Hello", "World");
            return oT;
        }

        [WebMethod]
        public List<String> getCustomerIDS()
        {
            List<String> ship = new List<String>();
            SqlConnection conn = new SqlConnection(@"Data Source = .; Database=Northwind; Integrated Security=true;");
            conn.Open();
            SqlCommand cmd = new SqlCommand("select ShipperID, CompanyName from Shippers", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ship.Add((String)dr["CompanyName"]);
            }
            return ship;
        }

        [WebMethod]
        public int MakeOrder(String CID, int SV)
        {
            SqlConnection oConn = new SqlConnection();
            oConn.ConnectionString = "Data Source=(local);"
                                   + "Initial Catalog=Northwind;"
                                   + "Integrated Security= true";
            oConn.Open();

            SqlCommand oCMD = new SqlCommand("AddOrder", oConn);
            oCMD.CommandType = CommandType.StoredProcedure;

            SqlParameter oParam;
            oParam = oCMD.Parameters.Add("@CustomerID", SqlDbType.NChar, 5);
            oParam = oCMD.Parameters.Add("@ShipVia", SqlDbType.Int);
            oParam = oCMD.Parameters.Add("@ret", SqlDbType.Int);
            oParam.Direction = ParameterDirection.ReturnValue;

            oCMD.Parameters["@CustomerID"].Value = CID;
            oCMD.Parameters["@ShipVia"].Value = SV;
            oCMD.ExecuteNonQuery();

            return int.Parse(oCMD.Parameters["@ret"].Value.ToString());
        }
    }
}
