using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;

namespace Cornflakes
{
    public partial class DemoForm : Form
    {
        public DemoForm()
        {
            InitializeComponent();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Serialise_Click(object sender, System.EventArgs e)
        {
            Employee emp = new Employee(int.Parse(TheNumber.Text), float.Parse(TheSalary.Text), TheName.Text);
            Stream s = new FileStream("cornflakes.dat", FileMode.Create);
            IFormatter f = new SoapFormatter();
            f.Serialize(s, emp);
            s.Flush();
            s.Close();
            s = new FileStream("cornflakes.dat", FileMode.Open);
            TextReader tr = new StreamReader(s);
            Serialised.Text = tr.ReadToEnd();
            s.Close();

        }

        private static void dotNetSerialize()
        {
            Employee emp = new Employee(1, 5000, "John Doe");
            FileStream s = new FileStream("cornflakes.dat", FileMode.Create);
            IFormatter f = new BinaryFormatter();
            f.Serialize(s, emp);

            s.Flush();
            s.Close();
        }

        private void Deserialise_Click(object sender, EventArgs e)
        {
            Stream s = new FileStream("cornflakes.dat", FileMode.Open);
            IFormatter f = new SoapFormatter();
            Employee demp = (Employee)f.Deserialize(s);
            s.Flush();
            s.Close();
            TheName.Text = demp.Name.ToString();
            TheNumber.Text = demp.Number.ToString(); 
            TheSalary.Text = demp.Salary.ToString();
            TheValue.Text = demp.SomeValue.ToString();
        }

    }
}
