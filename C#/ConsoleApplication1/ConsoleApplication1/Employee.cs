using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelloWorld
{
    abstract class Employee : BuildingOccupant, IPrintData
    {
        public int Number {  get; set; }

        public double Salary { get; set; }

                
    
        public Employee()
        {
            this.Name = "<unknown>";
            this.Number = -1;
            this.Salary = 0.0F;
        }

        public Employee(int newNumber, double newSalary, String newName)
        {
            this.Number = newNumber;
            this.Salary = newSalary;
            this.Name = newName;
        }

        public abstract void printPay();

        void IPrintData.print()
        {
            Console.WriteLine("Employee Print");
        }

        public override void logEntry()
        {
            //log in
        }

        public override void logExit()
        {
            //log out   
        }

        ~Employee()
        {
            Console.WriteLine("Destructor called {0}", Number);
        }
    }
}
