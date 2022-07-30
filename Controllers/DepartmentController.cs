using learn.core.Data;
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
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentservice departmentservice;
        public DepartmentController(IDepartmentservice departmentservice)
        {
            this.departmentservice = departmentservice;
        }
        [HttpDelete("{id}")]
        public bool deletedep(int id)
        {
            return departmentservice.deletedep(id);
        }
        [HttpGet]
        public List<Department_api> Department()
        {
            return departmentservice.getalldep();
        }
        [HttpGet("{id}")]
        public Department_api getbyid(int id)
        {
            return departmentservice.getbyid(id);
        }
        [HttpPost]
        public bool insertdep([FromBody] Department_api Department)
        {
            return departmentservice.insertdep(Department);
        }
        [HttpPut]
        public bool updatedep([FromBody] Department_api Department)
        {
            return departmentservice.updatedep(Department);
        }
    }
}
