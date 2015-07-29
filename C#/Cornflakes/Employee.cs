using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Cornflakes
{
    [Serializable]
    public class Employee : IDeserializationCallback, ISerializable
    {
        private int number;		// employee number
        private float salary;	// employee salary
        private string name;	// employee name
        [NonSerialized]  private int someValue;

        public int SomeValue 
        {
            get
            {
                return this.someValue;
            }

            set
            {
                this.someValue = value;
            }
        }

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

        public float Salary
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
        }

        public Employee(int aNumber, float aSalary, String aName)
        {
            number = aNumber;
            salary = aSalary;
            name = aName;
        }

        public Employee(SerializationInfo si, StreamingContext sc)
        {
            this.number = si.GetInt32("MyNumber");
            this.salary = si.GetSingle("Salary");
            this.name = si.GetString("DifferentValue");
        }

        public void OnDeserialization(Object o)
        {
            this.someValue = 33;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("MyNumber", this.number);
            info.AddValue("Salary", this.salary);
            info.AddValue("DifferentValue", this.name);
        }
    }
}
