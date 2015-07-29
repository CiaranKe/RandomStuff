using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;
using System.Xml.Xsl;
using System.IO;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace XMLWork
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ReadXML_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder ContentForDisplay = new StringBuilder();
            Display.Text = "";
            XmlTextReader xtr = new XmlTextReader(@"C:\Users\ciaranke\Documents\Visual Studio 2010\Projects\XMLWork\xml.xml");
            while (xtr.Read())
            {
                ContentForDisplay.Append("Type: " + xtr.NodeType + " Name: " + xtr.Name + " Value: " + xtr.Value + "\r\n");
            }

            Display.Text = ContentForDisplay.ToString();
        }

        private void WriteXML_Click(object sender, RoutedEventArgs e)
        {
            String conn = @"Data Source=.;Database=Northwind;Integrated Security=True;";
            SqlDataAdapter sda = new SqlDataAdapter("select * from products where UnitsOnOrder > 0", conn);
            DataSet ds = new DataSet();
            XmlDocument xd = new XmlDocument();
            XslCompiledTransform xt = new XslCompiledTransform();

            sda.Fill(ds, "ProductList");
            xd.LoadXml(ds.GetXml());
            xd.Save(@"C:\Users\ciaranke\Documents\Visual Studio 2010\Projects\XMLWork\Orders.xml");

            xt.Load(@"C:\Users\ciaranke\Documents\Visual Studio 2010\Projects\XMLWork\OrderSpec.xslt");
            xt.Transform(@"C:\Users\ciaranke\Documents\Visual Studio 2010\Projects\XMLWork\Orders.xml", @"C:\Users\ciaranke\Documents\Visual Studio 2010\Projects\XMLWork\Orders.html");
            
            /*
            XmlTextWriter xtr = new XmlTextWriter(@"C:\Users\ciaranke\Documents\Visual Studio 2010\Projects\XMLWork\output.xml", System.Text.Encoding.UTF8);
            xtr.Formatting = System.Xml.Formatting.Indented;
            xtr.Indentation = 4;
            xtr.WriteStartDocument();
            xtr.WriteStartElement("Now");
            xtr.WriteStartAttribute("name", "ans");
            xtr.WriteString("your name");
            xtr.WriteEndAttribute();
            xtr.WriteStartElement("time");
            xtr.WriteString("ttt");
            xtr.WriteEndElement();
            xtr.WriteStartElement("date");
            xtr.WriteStartElement("day");
            xtr.WriteString("dd");
            xtr.WriteEndElement();
            xtr.WriteStartElement("month");
            xtr.WriteString("mmm");
            xtr.WriteEndElement();
            xtr.WriteStartElement("year");
            xtr.WriteString("yyyy");
            xtr.WriteEndElement();
            xtr.WriteEndElement();
            xtr.WriteEndElement();
            xtr.WriteEndDocument();
            xtr.Flush();
            xtr.Close();
            */
        }

        private void ParseXML_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder ContentForDisplay = new StringBuilder();
            XmlDocument xd = new XmlDocument();
            
            xd.Load(@"C:\Users\ciaranke\Documents\Visual Studio 2010\Projects\XMLWork\xml.xml");
            XmlNode documentNode = xd.DocumentElement;
            Display.Text = " ";
            foreach (XmlNode xn in documentNode.ChildNodes.Item(0).ChildNodes)
            {
                ContentForDisplay.Append(xn.Value + "\n");
            }
            Display.Text = ContentForDisplay.ToString();
        }

        private void XPath_Click(object sender, RoutedEventArgs e)
        {
            XmlDocument xd = new XmlDocument();
            xd.Load(@"C:\Users\ciaranke\Documents\Visual Studio 2010\Projects\XMLWork\xml.xml");
            XmlNode documentNode = xd.DocumentElement;
            XmlNodeList xnl = documentNode.SelectNodes("/coursespec/title/text ()");
            Display.Text = xnl.Item(0).Value;
        }

        private void XSLT_Click(object sender, RoutedEventArgs e)
        {
            XslCompiledTransform xt = new XslCompiledTransform();
            xt.Load(@"C:\Users\ciaranke\Documents\Visual Studio 2010\Projects\XMLWork\spec.xsl");
            //xt.Transform(@"C:\Users\ciaranke\Documents\Visual Studio 2010\Projects\XMLWork\xml.xml", @"C:\Users\ciaranke\Documents\Visual Studio 2010\Projects\XMLWork\xml.html");      
            XmlDocument xd = new XmlDocument();
            xd.Load(@"C:\Users\ciaranke\Documents\Visual Studio 2010\Projects\XMLWork\xml.xml");
            StringWriter result = new StringWriter();
            xt.Transform(xd, null, result);
            Display.Text = result.ToString();
        }
    }
}