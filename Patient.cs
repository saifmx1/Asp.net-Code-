using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoginApplication.Models.Patient
{
    public class Patient
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SSN { get; set; }
        public string DOB { get; set; }
        public string Tele_No { get; set; }
        public string Age { get; set; }
        public string Minor_patient { get; set; }
        public string Address { get; set; }
        public string Country_code { get; set; }
        public string Country_Name { get; set; }
        public string Relationship_to_patient { get; set; }
        public string Guardian_Name { get; set; }

    }
}