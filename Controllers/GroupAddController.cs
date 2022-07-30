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
    public class GroupAddController : ControllerBase
    {
        private readonly IGroupAddservice groupAddservice;
        public GroupAddController(IGroupAddservice groupAddservice)
        {
            this.groupAddservice = groupAddservice;
        }
        [HttpDelete("{id}")]
        public bool deleteGroupAdd(int id)
        {
            return groupAddservice.deleteGroupAdd(id);
        }
        [HttpGet]
        public List<Groups_Add> getallGroupAdd()
        {
            return groupAddservice.getallGroupAdd();
        }
        [HttpGet("{id}")]
        public Groups_Add getbyidGroupAdd(int id)
        {
            return groupAddservice.getbyidGroupAdd(id);
        }
        [HttpPost]
        public bool insertGroupAdd([FromBody] Groups_Add GA)
        {
            return groupAddservice.insertGroupAdd(GA);
        }
        [HttpPut]
        public bool updateGroupAdd([FromBody] Groups_Add GA)
        {
            return groupAddservice.updateGroupAdd(GA);
        }
    }
}
