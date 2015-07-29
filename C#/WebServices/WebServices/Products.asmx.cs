using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace WebServices
{
    /// <summary>
    /// Summary description for Products
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Products : System.Web.Services.WebService
    {

        [WebMethod]
        public String getAvailibleProductsXML()
        {
            string conn = "Data Source=(local); Initial Catalog=Northwind; Integrated Security=True;";
            DataSet oDS = new DataSet();
            SqlDataAdapter oCMD = new SqlDataAdapter("AvailableProducts", conn);
            oCMD.Fill(oDS, "AvailableProductsList");
            return oDS.GetXml();
        }

    }
}
