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
    public class FreindController : ControllerBase
    {
        private readonly IFreindservice freindS;
        public FreindController(IFreindservice freindS)
        {
            this.freindS = freindS;
        }
        [HttpDelete("{id}")]
        public bool deleteFreinds(int id)
        {
            return freindS.deleteFreinds(id);
        }
        [HttpGet]
        public List<Freind_List> getallFreinds()
        {
            return freindS.getallFreinds();
        }
        [HttpGet("{id}")]
        public Freind_List getbyidFreinds(int id)
        {
            return freindS.getbyidFreinds(id);
        }
        [HttpPost]
        public bool insertFreinds([FromBody] Freind_List FL)
        {
            return freindS.insertFreinds(FL);
        }
        [HttpPut]
        public bool updateFreinds([FromBody] Freind_List FL)
        {
            return freindS.updateFreinds(FL);
        }
    }
}
