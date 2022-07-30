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
    public class TaskempController : ControllerBase
    {
        private readonly ITaskempservice taskempservice;
        public TaskempController(ITaskempservice taskempservice)
        {
            this.taskempservice = taskempservice;
        }
        [HttpDelete("{id}")]
        public bool deletetaskemp(int id)
        {
            return taskempservice.deletetaskemp(id);
        }
        [HttpGet]
        public List<Taskemp_api> taskemp_api()
        {
            return taskempservice.getalltaskemp();
        }
        [HttpGet("{id}")]
        public Taskemp_api getbyidtaskemp(int id)
        {
            return taskempservice.getbyidtaskemp(id);
        }
        [HttpPost]
        public bool inserttaskemp([FromBody] Taskemp_api task)
        {
            return taskempservice.inserttaskemp(task);
        }
        [HttpPut]
        public bool updatetaskemp([FromBody] Taskemp_api task)
        {
            return taskempservice.updatetaskemp(task);
        }
    }
}
