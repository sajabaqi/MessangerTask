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
    public class ServiceController : ControllerBase
    {
        private readonly IserviceService iserviceService;
        public ServiceController(IserviceService iserviceService)
        {
            this.iserviceService = iserviceService;
        }
        [HttpDelete("{id}")]
        public bool deleteService(int id)
        {
            return iserviceService.deleteService(id);
        }
        [HttpGet]
        public List<Service_api> getallService()
        {
            return iserviceService.getallService();
        }
        [HttpGet("{id}")]
        public Service_api getbyidService(int id)
        {
            return iserviceService.getbyidService(id);
        }
        [HttpPost]
        public bool insertService([FromBody] Service_api Service_)
        {
            return iserviceService.insertService(Service_);
        }
        [HttpPut]
        public bool updateService([FromBody] Service_api Service_)
        {
            return iserviceService.updateService(Service_);
        }
    }
}
