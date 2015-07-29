using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Reflection;

namespace Cornflakes
{
    class Manager: Employee, ISerializable
    {
        private int m_Reports;
        private float m_BonusPerReport;

        public void GetObjectData(SerializationInfo si, StreamingContext context)
        {
            Type t = typeof(Employee);
            MemberInfo[] mi = FormatterServices.GetSerializableMembers(t);
            Object os = FormatterServices.GetObjectData(this, mi);
            si.AddValue("EmployeeStuff", os);
            si.AddValue("Reports", this.m_Reports);
            si.AddValue("Bonus", this.m_BonusPerReport);
        }

        private Manager(SerializationInfo si, StreamingContext sc)
        {
            Type t = typeof(Employee);
            MemberInfo[] mi = FormatterServices.GetSerializableMembers(t);
            Object [] os = (Object[])si.GetValue("EmployeeStuff", typeof(Object[]));
            FormatterServices.PopulateObjectMembers(this, mi, os);
            this.m_Reports = si.GetInt32("Reports");
            this.m_BonusPerReport = si.GetSingle("Bonus");
        }
    }
}
