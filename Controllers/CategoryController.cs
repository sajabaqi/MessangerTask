using learn.core.Data;
using learn.core.service;
using learn.infra.service;
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
    public class CategoryController : ControllerBase
    {
        private readonly Icategoryservice categoryservice;
        public CategoryController(Icategoryservice categoryservice)
        {
             this.categoryservice = categoryservice;
        }
        [HttpDelete("{id}")]
        public bool deletecat(int id)
        {
            return categoryservice.deletecat(id);
        }
        [HttpGet]
        public List<categorey_api> categorey()
        {
            return categoryservice.getallcat();
        }
        [HttpGet("{id}")]
        public categorey_api getbyid(int id)
        {
            return categoryservice.getbyid(id);
        }
        [HttpPost]
        public bool insertcat([FromBody]categorey_api capi)
        {
            return categoryservice.insertcat(capi);
        }
        [HttpPut]
        public bool updatecat([FromBody]categorey_api capi)
        {
            return categoryservice.updatecat(capi);
        }
    }
}
