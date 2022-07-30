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
    public class CourseController : ControllerBase
    {
        private readonly Icourseservice courseservice;
        public CourseController(Icourseservice courseservice)
        {
            this.courseservice = courseservice;
        }
        [HttpDelete("{id}")]
        public bool deletecourse(int id)
        {
            return courseservice.deletecourse(id);
        }
        [HttpGet]
        public List<course1_api> cc()
        {
            return courseservice.getallcourse();
        }
        [HttpPost]
        public bool createinsertcourse([FromBody]course1_api capi)
        {
            return courseservice.createinsertcourse(capi);
        }
        [HttpGet]
        [Route("Coursessum")]
        public double price()
        {
            return courseservice.Price();
        }
        [HttpGet]
        [Route("Courserecord")]
        public List<course1_api> Lastrecords()
        {
            return courseservice.Lastrecords();
        }
        [HttpGet]
        [Route("Order")]
        public List<course1_api> Orderby()
        {
            return courseservice.Orderby();
        }
    }
}
