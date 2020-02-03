using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LoginApplication.Models;
using LoginApplication.Models.Patient;
using LoginApplication.Models.VM;

namespace LoginApplication.Controllers
{
    [RoutePrefix("Api/Patient")]
    public class PatientController : ApiController
    {
        tempdbEntities DB = new tempdbEntities();
        [Route("AddorUpdatepatient")]
        [HttpPost]
        public object AddorUpdatepatient(Patient pat)
        {
            try
            {
                if(pat.Id ==0)
                {
                    patient_details pd = new patient_details();
                    pd.FirstName = pat.FirstName;
                    pd.LastName = pat.LastName;
                    pd.SSN = pat.SSN;
                    pd.DOB = pat.DOB;
                    pd.Tele_No = pat.Tele_No;
                    pd.Age = pat.Age;
                    pd.Minor_patient = pat.Minor_patient;
                    pd.Address = pat.Address;
                    pd.Country_code = pat.Country_code;
                    pd.Country_Name = pat.Country_Name;
                    pd.Relationship_to_patient = pat.Relationship_to_patient;
                    pd.Guardian_Name = pat.Guardian_Name;
                    DB.patient_details.Add(pd);
                    DB.SaveChanges();
                    return new Response
                    {
                        Status = "Success",
                        Message = "Sucessfully saved to database."
                    };
                }
                else
                {
                    var obj = DB.patient_details.Where(x => x.Id == pat.Id).ToList().FirstOrDefault();
                    if(obj.Id>0)
                    {
                        obj.FirstName = pat.FirstName;
                        obj.FirstName = pat.FirstName;
                        obj.LastName = pat.LastName;
                        obj.SSN = pat.SSN;
                        obj.DOB = pat.DOB;
                        obj.Tele_No = pat.Tele_No;
                        obj.Age = pat.Age;
                        obj.Minor_patient = pat.Minor_patient;
                        obj.Address = pat.Address;
                        obj.Country_code = pat.Country_code;
                        obj.Country_Name = pat.Country_Name;
                        obj.Relationship_to_patient = pat.Relationship_to_patient;
                        obj.Guardian_Name = pat.Guardian_Name;
                        DB.SaveChanges();
                        return new Response
                        {
                            Status = "Updated",
                            Message = "Sucessfully Updated"
                        };
                    }
                }
            }
            catch(Exception ex)
            {
                Console.Write(ex.Message);
            }
            return new Response
            {
                Status = "Error",
                Message = "Data not inserted."
            };
        }

        [Route("PatientDetails")]
        [HttpGet]
        public object PatientDetails()
        {
            var patdetails = DB.patient_details.ToList();
            return patdetails;
        }

        [Route("PatientdetailsById")]
        [HttpGet]
        public object PatientdetailsById(int id)
        {
            var obj = DB.patient_details.Where(x => x.Id == id).ToList().FirstOrDefault();
            return obj;
        }

        [Route("DeletePatient")]
        [HttpDelete]
        public object DeletePatient(int id)
        {
            var obj = DB.patient_details.Where(x => x.Id == id).ToList().FirstOrDefault();
            DB.patient_details.Remove(obj);
            DB.SaveChanges();
            return new Response
            {
                Status = "Delete",
                Message = "Deleted Successfully"
            };
        }

    }
}
