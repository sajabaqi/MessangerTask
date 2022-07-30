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
    public class TaskController : ControllerBase
    {
        private readonly ITaskservice taskservice;
        public TaskController(ITaskservice taskservice)
        {
            this.taskservice = taskservice;
        }
        [HttpDelete("{id}")]
        public bool deletetask(int id)
        {
            return taskservice.deletetask(id);
        }
        [HttpGet]
        public List<Task_api> task()
        {
            return taskservice.getalltask();
        }
        [HttpGet("{id}")]
        public Task_api getbyidtask(int id)
        {
            return taskservice.getbyidtask(id);
        }
        [HttpPost]
        public bool inserttask([FromBody] Task_api task)
        {
            return taskservice.inserttask(task);
        }
        [HttpPut]
        public bool updatetask([FromBody] Task_api task)
        {
            return taskservice.updatetask(task);
        }
    }
}
