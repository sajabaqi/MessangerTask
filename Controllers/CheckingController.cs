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
    public class CheckingController : ControllerBase
    {
        private readonly ICheckingservice checkingservice;
        public CheckingController(ICheckingservice checkingservice)
        {
            this.checkingservice = checkingservice;
        }
        [HttpDelete("{id}")]
        public bool deletech(int id)
        {
            return checkingservice.deletech(id);
        }
        [HttpGet]
        public List<Checking1> checking1()
        {
            return checkingservice.getallch();
        }
        [HttpGet("{id}")]
        public Checking1 getbyidch(int id)
        {
            return checkingservice.getbyidch(id);
        }
        [HttpPost]
        public bool insertch([FromBody] Checking1 checking1)
        {
            return checkingservice.insertch(checking1);
        }
        [HttpPut]
        public bool updatech([FromBody] Checking1 Ch)
        {
            return checkingservice.updatech(Ch);
        }
        [HttpPost("gg")]

        public List<Salary> getbyfiltering([FromBody]Filterdate_dto emp)
        {
            return checkingservice.getbyfiltering(emp);

        }

    }
}
