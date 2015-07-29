using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebbyStuff.Models
{
    public class SalesEmployee : Employee
    {
        public double ComissionRate { get; set; }
        public int NumSales { get; set; }
        public double Comission { get { return this.NumSales / this.ComissionRate; } }

        public SalesEmployee()
            : base()
        {
            this.ComissionRate = 0;
            this.NumSales = 0;
        }

        public SalesEmployee(int newNumber, double newSalary, String newName, String Dept, double newCommision, int newNumSales)
            : base(newNumber, newSalary, newName, Dept)
        {
            this.ComissionRate = newCommision;
            this.NumSales = newNumSales;
        }
    }
}