using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelloWorld
{
    class Manager : Employee, IPrintData
    {
        public int Reports { get; set; }
        public float BonusPerReport { get; set; }

        public Manager()
            : base()
        {
            this.Reports = 0;
            this.BonusPerReport = 0;
        }

        public Manager(int newNumber, float newSalary, String newName, int newReports, float newBonus)
            : base(newNumber, newSalary, newName)
        {
            this.Reports = newReports;
            this.BonusPerReport = newBonus;
        }

        public override void printPay()
        {
            Console.WriteLine("Employee {0} is paid {1} per month", this.Name, (this.Salary / 12) + (this.Reports * this.BonusPerReport));
        }

        void IPrintData.print()
        {
            Console.WriteLine("Manager Print");
        }
    }
}
