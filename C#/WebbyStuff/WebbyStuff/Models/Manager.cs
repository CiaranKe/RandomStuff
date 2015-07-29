using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebbyStuff.Models
{
    public class Manager :Employee
    {
        private int m_Reports;
        private double m_BonusPerReport;
        public int Reports 
        {
            get
            {
                return m_Reports;
            }
            set
            {
                m_Reports = value;
            }
        }
        public double BonusPerReport 
        {
            get
            {
                return m_BonusPerReport;
            }
            set
            {
                m_BonusPerReport = value;
            } 
        }

        public Manager()
            : base()
        {
            this.Reports = 0;
            this.BonusPerReport = 0;
        }

        public Manager(int newNumber, double newSalary, String newName, String newDept, int newReports, double newBonus)
            : base(newNumber, newSalary, newName, newDept)
        {
            this.Reports = newReports;
            this.BonusPerReport = newBonus;
        }
    }
}