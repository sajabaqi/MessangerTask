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
    public class GroupCreateController : ControllerBase
    {
        private readonly IGroupservice Groupservice;
        public GroupCreateController(IGroupservice Groupservice)
        {
            this.Groupservice = Groupservice;
        }
        [HttpDelete("{id}")]
        public bool deleteGroups(int id)
        {
            return Groupservice.deleteGroups(id);
        }
        [HttpGet]
        public List<Group_Create> getallGroups()
        {
            return Groupservice.getallGroups();
        }
        [HttpGet("{id}")]
        public Group_Create getbyidGroups(int id)
        {
            return Groupservice.getbyidGroups(id);
        }
        [HttpPost]
        public bool insertGroups([FromBody] Group_Create GC)
        {
            return Groupservice.insertGroups(GC);
        }
        [HttpPut]
        public bool updateGroups([FromBody] Group_Create GC)
        {
            return Groupservice.updateGroups(GC);
        }
    }
}
