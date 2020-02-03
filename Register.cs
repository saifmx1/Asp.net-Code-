using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoginApplication.Models.VM
{
    public class Register
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string EmployeeName { get; set; }
        public string City { get; set; }
        public string Department { get; set; }
    }
}