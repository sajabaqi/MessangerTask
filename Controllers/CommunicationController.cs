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
    public class CommunicationController : ControllerBase
    {
        private readonly ICommunicationservice communicationservice;
        public CommunicationController(ICommunicationservice communicationservice)
        {
            this.communicationservice = communicationservice;
        }
        [HttpDelete("{id}")]
        public bool deleteMessage(int id)
        {
            return communicationservice.deleteMessage(id);
        }
        [HttpGet]
        public List<Communication> communication()
        {
            return communicationservice.getallMessage();
        }
        [HttpGet("Count")]
        public int CountMessage()
        {
            return communicationservice.CountMessage();
        }
        [HttpGet("{id}")]
        public Communication getbyidMessage(int id)
        {
            return communicationservice.getbyidMessage(id);
        }
        [HttpPost]
        public bool insertMessage([FromBody] Communication com)
        {
            return communicationservice.insertMessage(com);
        }
        [HttpPost("Date")]
        public List<Between_dto> getdateBetween([FromBody] Between_dto between_)
        {
            return communicationservice.getdateBetween(between_);
        }
        [HttpPut]
        public bool updateMessage([FromBody] Communication com)
        {
            return communicationservice.updateMessage(com);
        }
    }
}
