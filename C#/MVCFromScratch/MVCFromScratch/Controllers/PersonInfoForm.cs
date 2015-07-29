using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCFromScratch.Controllers
{
    public class PersonInfoForm
    {
        public String Firstname { get; set; }
        public String LastName { get; set; }
        public String Gender { get; set; }
        public String Salutation { get; set; }
        public List<String> Interests { get; set; }
    }
}