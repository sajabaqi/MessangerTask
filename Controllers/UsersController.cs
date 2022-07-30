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
    public class UsersController : ControllerBase
    {
        private readonly IUsersservice userservice;
        private readonly IEmalservice emailservice;
        public UsersController(IUsersservice userservice, IEmalservice emailservice)
        {
            this.userservice = userservice;
            this.emailservice = emailservice;
        }
        [HttpDelete("{id}")]
        public bool deleteUsers(int id)
        {
            return userservice.deleteUsers(id);
        }
        [HttpGet("AddBackup/{Name}")]
        public string AddBackup(Users_Task UT, string Name)
        {
            return userservice.AddBackup(UT,Name);
        }
        [HttpGet]
        public List<Users_Task> getallUsers()
        {
            return userservice.getallUsers();
        }
        [HttpGet("Eachmess")]
        public List<eachMess_dto> eachCount()
        {
            return userservice.eachCount();
        }
        [HttpGet("EachLikes")]
        public List<EachLike_dto> EachLikes()
        {
            return userservice.EachLikes();
        }
        [HttpGet("CountCountry")]
        public List<CountCountry_dto> CountCountry()
        {
            return userservice.CountCountry();
        }
        [HttpGet("{id}")]
        public Users_Task getbyidUsers(int id)
        {
            return userservice.getbyidUsers(id);
        }
        [HttpPost]
        [Route("Block")]
        public List<BlockF_dto> BlockF([FromBody] BlockF_dto blockF_)
        {
            return userservice.BlockF(blockF_);
            //if (BF.MemberStatue == "0" && BF.MemberID == id)
            //{
            //    return "This User Blocked";
            //}
            //else
            //{
            //    return "This user is in Group";
            //}
        }
        [HttpPost]
        public bool insertUsers([FromBody] Users_Task Users)
        {
            return userservice.insertUsers(Users);
        }
        [HttpPut]
        public bool updateUsers([FromBody] Users_Task Users)
        {
            return userservice.updateUsers(Users);
        }
        [HttpPost("Filter")]
        public List<filterDto> filtername([FromBody] filterDto fil)
        {
            return userservice.filtername(fil);
        }
        [HttpPost]
        [Route("FiveRecord")]
        public List<Users_Task> Insert5Users([FromBody] Users_Task[] course)
        {
            return userservice.Insert5Users(course);
        }
        [HttpPost]
        [Route("Insert")]
        public bool Insert( IFormFile FilePath)
        {
            return userservice.Insert(FilePath);
        }
    }
}
