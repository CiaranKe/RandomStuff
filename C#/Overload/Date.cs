using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Overload
{
    class Date
    {
        private short day;
        private short month;
        private short year;

        public Date(short day, short month, short year)
        {
            this.day = day;
            this.month = month;
            this.year = year;
        }

        public void Print()
        {
            Console.WriteLine("{0}/{1}/{2}", day, month, year);
        }

        //overload ==

        public static bool operator ==(Date a, Date b)
        {
            if (a.day == b.day && a.month == b.month && a.year == b.year)
            {
                return true;
            }
            return false;
        }

        public static bool operator !=(Date a, Date b)
        {
            if (a.day != b.day || a.month != b.month || a.year != b.year)
            {
                return true;
            }
            return false;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Date))
            {
                return false;
            }
            return this == (Date)obj;
        }

        public override int GetHashCode()
        {
            int hc = 1;
            hc = 37 * hc + day << 16 | (ushort)day;
            hc = 37 * hc + day << 16 | (ushort)month;
            hc = 37 * hc + day << 16 | (ushort)year;
            
            return hc;
        }

        public static explicit operator Date(String s)
        {
            return new Date(short.Parse(s.Substring(0,2)),
                            short.Parse(s.Substring(3,2)),
                            short.Parse(s.Substring(6,4)));
        }

        public static implicit operator string(Date d)
        {
            String s = d.day.ToString() + "/"
                 + d.month.ToString() + "/"
                 + d.year.ToString();

            return s;
        }
    }
}
