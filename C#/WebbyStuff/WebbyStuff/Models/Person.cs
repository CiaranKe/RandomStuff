using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace WebbyStuff.Models
{
    public class Person
    {
        private String salutation;
        private String firstName;
        private String lastName;
        private String gender;
        private List<String> interests;

        
        public String Salutation { get { return this.salutation; } set { this.salutation = value; } }

        [Required(ErrorMessage="You must provide a first name")]
        [DisplayName("First Name")]
        public String FirstName {get {return this.firstName;} set {this.firstName = value;}}

        [Required(ErrorMessage = "You must provide a last name")]
        [DisplayName("Last Name")]
        public String LastName { get { return this.lastName; } set { this.lastName = value; } }

        [Required(ErrorMessage = "You must specify a Gender")]
        [DisplayName("Gender")]
        public String Gender { get { return this.gender; } set { this.gender = value; } }
        public List<String> Interests { get { return this.interests; } set { this.interests = value; } }

        public Person()
        {
        }
        public Person(String nf, String nl, String ng, List<String> ni)
        {
            this.firstName = nf;
            this.lastName = nl;
            this.gender = ng;
            this.interests = ni;
        }

        public Person(String nf, String nl, String ng)
        {
            this.firstName = nf;
            this.lastName = nl;
            this.gender = ng;
        }
    }
}