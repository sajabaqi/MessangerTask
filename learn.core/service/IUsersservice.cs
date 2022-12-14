using learn.core.Data;
using learn.core.DTO;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.core.service
{
    public interface IUsersservice
    {
        public List<Users_Task> getallUsers();
        public bool updateUsers(Users_Task users);
        public bool deleteUsers(int id);
        public bool insertUsers(Users_Task users);
        public Users_Task getbyidUsers(int id);
        public List<eachMess_dto> eachCount();
        public List<EachLike_dto> EachLikes();
        public List<Users_Task> Insert5Users(Users_Task[] FiveRecords);
        public List<BlockF_dto> BlockF(BlockF_dto blockF_);
        public string AddBackup(Users_Task UT, string Name);
        public List<filterDto> filtername(filterDto fil);
        public List<CountCountry_dto> CountCountry();
        public bool Insert(IFormFile FilePath);
    }
}
