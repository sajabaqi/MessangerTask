using Dapper;
using learn.core.Data;
using learn.core.domian;
using learn.core.DTO;
using learn.core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace learn.infra.Repository
{
    public class UsersRepository : IUser_repository
    {
        private readonly IDBcontext dbContext;
        public UsersRepository(IDBcontext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<eachMess_dto> eachCount()
        {
            IEnumerable<eachMess_dto> result = dbContext.dbConnection.Query<eachMess_dto>("Users_package_api.eachCount", commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

        public bool deleteUsers(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("idofUsers", id, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            dbContext.dbConnection.Execute("Users_package_api.deleteUsers", parameter, commandType: CommandType.StoredProcedure);
            return true;
        }

        public List<Users_Task> getallUsers()
        {
            IEnumerable<Users_Task> result = dbContext.dbConnection.Query<Users_Task>("Users_package_api.getallUsers", commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

        public Users_Task getbyidUsers(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("idofUsers", id, dbType: DbType.Decimal, direction: ParameterDirection.Input);

            IEnumerable<Users_Task> result = dbContext.dbConnection.Query<Users_Task>("Users_package_api.getbyidUsers", parameter, commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }

        public bool insertUsers(Users_Task users)
        {
            var parameter = new DynamicParameters();
            parameter.Add("idofUsers", users.id, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            parameter.Add("fname", users.fullname, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("uname", users.username, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("e_mail", users.email, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("rolofid", users.idrole1, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("verf", users.Verfication_code, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("sid", users.ServiceId, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("Addr", users.Address, dbType: DbType.String, direction: ParameterDirection.Input);
            

            dbContext.dbConnection.ExecuteAsync("Users_package_api.insertUsers", parameter, commandType: CommandType.StoredProcedure);

            return true;
        }

        public bool updateUsers(Users_Task users)
        {
            var parameter = new DynamicParameters();
            parameter.Add("idofUsers", users.id, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            parameter.Add("fname", users.fullname, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("uname", users.username, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("e_mail", users.email, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("rolofid", users.idrole1, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            parameter.Add("verf", users.Verfication_code, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("sid", users.ServiceId, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("Addr", users.Address, dbType: DbType.String, direction: ParameterDirection.Input);


            dbContext.dbConnection.ExecuteAsync("Users_package_api.updateUsers", parameter, commandType: CommandType.StoredProcedure);

            return true;
        }

        public List<Users_Task> Insert5Users(Users_Task[] FiveRecords)
        {
            for (int i = 0; i < FiveRecords.Length; i++)
            {
                insertUsers(FiveRecords[i]);
            }

            return FiveRecords.ToList();
        }

        public List<BlockF_dto> BlockF(BlockF_dto blockF_)
        {
            var parameter = new DynamicParameters();
            parameter.Add("E_mail", blockF_.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("MemState", blockF_.MemState, dbType: DbType.String, direction: ParameterDirection.Input);

            IEnumerable<BlockF_dto> result = dbContext.dbConnection.Query<BlockF_dto>("Users_package_api.BlockF", parameter,commandType: CommandType.StoredProcedure);

            return result.ToList();


        }
        public List<BlockF_dto> AllBlock(BlockF_dto blockF_)
        {
            IEnumerable<BlockF_dto> result = dbContext.dbConnection.Query<BlockF_dto>("Users_package_api.BlockF", commandType: CommandType.StoredProcedure);

            return result.ToList();


        }

        public List<CountCountry_dto> CountCountry()
        {
            IEnumerable<CountCountry_dto> result = dbContext.dbConnection.Query<CountCountry_dto>("Users_package_api.CountCountry", commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

        public List<EachLike_dto> EachLikes()
        {
            IEnumerable<EachLike_dto> result = dbContext.dbConnection.Query<EachLike_dto>("Users_package_api.EachLikes", commandType: CommandType.StoredProcedure);

            return result.ToList();
        }
        public string AddBackup(Users_Task UT, string Name)
        {
                List<Users_Task> U = getallUsers();
                using (StreamWriter sw = File.CreateText(@"C:\Users\SAJA ABU-BAQI\Desktop\Backup1.txt"))
                {
                
                    sw.WriteLine("Back up for your information");
                    sw.WriteLine("");
                        for (int j = 0; j < U.Count; j++)
                        {
                    if (U[j].fullname == Name)
                    {
                        sw.WriteLine("FullName : ", U[j].fullname);
                        sw.WriteLine("UserName : ", U[j].username);
                        sw.WriteLine("Email : ", U[j].email);
                        sw.WriteLine("RoleId : ", U[j].idrole1);
                        sw.WriteLine("Verfication_code : ", U[j].Verfication_code);
                    }
                        }
                        sw.WriteLine("==============");
                    
                }
            return "Backu successfully Added";
        }

        public List<filterDto> filtername(filterDto fil)
        {
            var parameter = new DynamicParameters();
            parameter.Add("byname", fil.byname, dbType: DbType.String, direction: ParameterDirection.Input);

            IEnumerable<filterDto> result = dbContext.dbConnection.Query<filterDto>("Users_package_api.filtername", parameter, commandType: CommandType.StoredProcedure);

            return result.ToList();


        }
    }
}
