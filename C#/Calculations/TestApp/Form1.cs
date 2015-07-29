using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TestApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var result = 0;
            Calculations.Basic x = new Calculations.Basic();

            result = x.add(23, 45);
            MessageBox.Show(result.ToString());
        }

    }
}
