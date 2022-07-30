using learn.core.Data;
using learn.core.DTO;
using learn.core.Repository;
using learn.core.service;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace learn.infra.service
{
    public class Userservice : IUsersservice
    {
        private readonly IUser_repository user_repository;
        public Userservice(IUser_repository user_repository)
        {
            this.user_repository = user_repository;
        }

        //public BlockF_dto BlockF( int id)
        //{
            
        //}

        public List<BlockF_dto> BlockF(BlockF_dto blockF_)
        {
            return user_repository.BlockF(blockF_);
        }

        public List<CountCountry_dto> CountCountry()
        {
            return user_repository.CountCountry();
        }

        public bool deleteUsers(int id)
        {
            return user_repository.deleteUsers(id);
        }

        public List<eachMess_dto> eachCount()
        {
            return user_repository.eachCount();
        }

        public List<EachLike_dto> EachLikes()
        {
            return user_repository.EachLikes();
        }

        public List<Users_Task> getallUsers()
        {
            return user_repository.getallUsers();
        }

        public Users_Task getbyidUsers(int id)
        {
            return user_repository.getbyidUsers(id);
        }

        public List<Users_Task> Insert5Users(Users_Task[] FiveRecords)
        {
            return user_repository.Insert5Users(FiveRecords);
        }

        public bool insertUsers(Users_Task users)
        {
            return user_repository.insertUsers(users);
        }

        public bool updateUsers(Users_Task users)
        {
            return user_repository.updateUsers(users);
        }
        public string AddBackup(Users_Task UT, string Name)
        {
            return user_repository.AddBackup(UT,Name);
        }

        public List<filterDto> filtername(filterDto fil)
        {
            return user_repository.filtername(fil);
        }
        public bool Insert(IFormFile FilePath)
        {

            List<Users_Task> users = new List<Users_Task>();

            string[] EmailDomain = { "@gmail.com", "@hotmail.com", "@yahoo.com" };
            string[] Countries = { "Amman", "Irbid", "Aqaba", "Karak", "Madaba","Zarqa", "Al-tafila", "Ajloun", "Jerash"};
            try
            {

                using (StreamReader sr = File.OpenText(@"C:\Users\SAJA ABU-BAQI\Postman\files\emp.txt"))
                {

                    while (!sr.EndOfStream)

                    {

                        string[] parts = sr.ReadLine().Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries);
                        Users_Task user = new Users_Task();

                        Random r = new Random();
                        int r2 = r.Next(10, 40);
                        int r1 = r.Next(0, 3);
                        int r3 = r.Next(1000, 9999);

                        int rinti = r.Next(0, 12);

                        user.fullname = parts[0];
                        user.username = parts[0] + "123";
                        if(r2 != user.id) {
                            user.id = r2;
                                }
                        user.Verfication_code = r3.ToString();
                        user.ServiceId = 1;
                        user.idrole1 = 1;
                        user.email = parts[0] + EmailDomain[r1];

                        StringBuilder stringBuilder = new StringBuilder();

                        user.Address = Countries[rinti];

                        users.Add(user);

                    }
                    sr.Close();
                }

            }
            catch (Exception)

            {
                return false;
            }
            for (int i = 0; i < users.Count; i++)
            {

                insertUsers(users[i]);
            }
            return true;
        }
}
}
