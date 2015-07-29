using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;

namespace WebbyStuff.Models
{
    public class Employee
    {
        private int number;		// employee number
        private double salary;	// employee salary
        private string name;	// employee name
        private string department; 

        public int Number
        {
            get
            {
                return number;
            }
            set
            {
                number = value;
            }
        }

        public double Salary
        {
            get
            {
                return salary;
            }
            set
            {
                salary = value;
            }
        }
        public string Department
        {
            get
            {
                return department;
            }
            set
            {
                department = value;
            }
        }

        public String Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public Employee()
        {
            number = -1;
            salary = 0.0f;
            name = "<Unknown>";
            department = "none";
        }

        public Employee(int aNumber, double aSalary, String aName, String aDept)
        {
            number = aNumber;
            salary = aSalary;
            name = aName;
            department = aDept;
        }
    }
}