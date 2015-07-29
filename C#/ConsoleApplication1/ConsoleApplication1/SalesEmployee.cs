using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelloWorld
{
    class SalesEmployee : Employee, IPrintData
    {
        float ComissionRate {get; set; }
        int NumSales { get; set; }
        float Comission { get { return this.NumSales / this.ComissionRate; } }
        
        public SalesEmployee()
            : base()
        {
            this.ComissionRate = 0;
            this.NumSales = 0;
        }

        public SalesEmployee(int newNumber, double newSalary, String newName, float newCommision, int newNumSales)
            : base(newNumber, newSalary, newName)
        {
            this.NumSales = newNumSales;
        }

        public override void printPay()
        {
            Console.WriteLine("Employee {0} is paid {1} per month", this.Name, ((this.Salary / 12) + (this.NumSales / this.Comission)));
        }

        void IPrintData.print()
        {
            Console.WriteLine("Sales Employee Print");
        }
    }
}
