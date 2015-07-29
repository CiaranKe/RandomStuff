using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServices.Models
{
    public class Test
    {
        private string ma;
        private string mb;
        private string mc = "Not me";

        public Test()
        {
            this.ma = "Default";
            this.mb = "Default";
        }

        public Test(string pa, string pb)
        {
            this.ma = pa;
            this.mb = pb;
        }

        public String A
        {
            get
            {
                return this.ma;
            }
            set
            {
                this.ma = value;
            }
        }

        public String B
        {
            get
            {
                return this.mb;
            }
            set
            {
                this.mb = value;
            }
        }
    }
}