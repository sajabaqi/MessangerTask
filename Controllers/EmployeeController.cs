using learn.core.Data;
using learn.core.DTO;
using learn.core.service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Apimonth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeservice employeeservice;
        public EmployeeController(IEmployeeservice employeeservice)
        {
            this.employeeservice = employeeservice;
        }
        [HttpDelete("{id}")]
        public bool deleteemp(int id)
        {
            return employeeservice.deleteemp(id);
        }
        [HttpGet]
        [Route("Get")]
        public List<Employee1_api> employee1_api()
        {
            return employeeservice.getallemp();
        }
        [HttpGet("{id}")]
        public Employee1_api getbyidemp(int id)
        {
            return employeeservice.getbyidemp(id);
        }
        [HttpPost]
        public bool insertemp([FromBody] Employee1_api emp)
        {
            return employeeservice.insertemp(emp);
        }
        [HttpPut]
        public bool updateemp([FromBody] Employee1_api emp)
        {
            return employeeservice.updateemp(emp);
        }
        [HttpGet]
        [Route("Getfull")]
        public List<Emp_dto> getfull()
        {
            return employeeservice.getfull();
        }
        [HttpGet]
        [Route("GetTas")]
        public List<Task_dto> gettask()
        {
            return employeeservice.gettask();
        }
        [HttpGet]
        [Route("Eachdep")]
        public List<eachDep_dto> eachdep()
        {
            return employeeservice.eachdep();
        }
        [HttpGet]
        [Route("eachtasks")]
        public List<eachtasks_dto> geteachtask()
        {
            return employeeservice.geteachtask();
        }
        //[HttpPost]
        //[Route("Filtering")]
        //public List<Filterdate_dto> getbyfiltering(Checking1 Filterdate)
        //{
        //    return employeeservice.getbyfiltering(Filterdate);
        //}
        [HttpGet]
        [Route("checkemail")]
        public List<Check_dto> checkemail()
        {
            return employeeservice.checkemail();
        }
        [HttpGet]
        [Route("gettaskid/{id}")]
        public List<gettask_dto> gettaskid(int id)
        {
            return employeeservice.gettaskid(id);
        }
        [HttpGet]
        [Route("count")]
        public int countOfEmployee()
        {
            return employeeservice.countOfEmployee();
        }
        [HttpGet]
        [Route("Sum")]
        public string Sum()
        {
        
            return employeeservice.Sum();
        }
        [HttpGet]
        [Route("filter/{c}")]
        public List<Employee1_api> Filtername(char c)
        {
            return employeeservice.Filtername(c);
        }
        [HttpGet]
        [Route("checkemailor")]
        public List<Check_dto> checkemailor()
        {
            return employeeservice.checkemailor();
        }
        [HttpGet]
        [Route("Avg")]
        public string Avg()
        {
            return employeeservice.Avg();
        }
        [HttpGet]
        [Route("All")]
        public string All()
        {
            return employeeservice.All();
        }
        [HttpGet]
        [Route("Ch/{email}")]
        public string Checkemail(string email)
        {
            return employeeservice.Checkemail(email);
        }
    }
}
