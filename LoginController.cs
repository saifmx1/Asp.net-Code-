using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LoginApplication.Models;
using LoginApplication.Models.VM;


namespace LoginApplication.Controllers
{
    [RoutePrefix("Api/login")]
    public class LoginController : ApiController
    {
        tempdbEntities DB = new tempdbEntities();
        [Route("InsertEmployee")]
        [HttpPost]
        public object InsertEmployee(Register Reg)
        {
            try
            {

                EmployeeLogin EL = new EmployeeLogin();
                if(EL.Id == 0)
                {
                    EL.EmployeeName = Reg.EmployeeName;
                    EL.City = Reg.City;
                    EL.Email = Reg.Email;
                    EL.Password = Reg.Password;
                    EL.Department = Reg.Department;
                    DB.EmployeeLogins.Add(EL);
                    DB.SaveChanges();
                    return new Response
                    { Status = "Success", Message = "Sucessfully saved to database." };
                }
            }
            catch(Exception)
            {
                throw;
            }
            return new Response
            { Status = "Error", Message = "Invalid Data" };
        }
        
        [Route("Login")]
        [HttpPost]
        public Response employeeLogin(Login login)
        {
            var log = DB.EmployeeLogins.Where(x => x.Email.Equals(login.Email) && x.Password.Equals(login.Password)).FirstOrDefault();
            if(log == null)
            {
                return new Response
                { Status = "Invalid", Message = "Invalid User." };
            }
            else
            {
                return new Response
                { Status = "Success", Message = "Login Successfully" };
            }
        } 
    }
}
