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
    public class Communication_repository : ICommunication_repository
    {
        private readonly IDBcontext dbContext;
        public Communication_repository(IDBcontext dbContext)
        {
            this.dbContext = dbContext;
        }

        public int CountMessage()
        {
            List<Communication> c = getallMessage();

            return  c.Count();
        }

        public bool deleteMessage(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("idofMessage", id, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            dbContext.dbConnection.Execute("Communication_package_api.deleteMessage", parameter, commandType: CommandType.StoredProcedure);
            return true;
        }

        public List<Communication> getallMessage()
        {
            IEnumerable<Communication> result = dbContext.dbConnection.Query<Communication>("Communication_package_api.getallMessage", commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

        public Communication getbyidMessage(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("idofMessage", id, dbType: DbType.Decimal, direction: ParameterDirection.Input);

            IEnumerable<Communication> result = dbContext.dbConnection.Query<Communication>("Communication_package_api.getbyidMessage", parameter, commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }

        public List<Between_dto> getdateBetween(Between_dto between_)
        {
            List<Communication> C = getallMessage();
            var parameter = new DynamicParameters();
            parameter.Add("startdate1", between_.startdate1, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            parameter.Add("enddate1", between_.enddate1, dbType: DbType.DateTime, direction: ParameterDirection.Input);

            IEnumerable<Between_dto> result = dbContext.dbConnection.Query<Between_dto>("Communication_package_api.getdateBetween", parameter, commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

        public bool insertMessage(Communication com)
        {
            var parameter = new DynamicParameters();
            parameter.Add("idofMessage", com.id, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            parameter.Add("from1", com.Message_From, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("Message", com.The_Message, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("sdate", com.sent_date, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            parameter.Add("rid", com.reciver_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("sid", com.sent_id, dbType: DbType.Int32, direction: ParameterDirection.Input);



            dbContext.dbConnection.ExecuteAsync("Communication_package_api.insertMessage", parameter, commandType: CommandType.StoredProcedure);

            return true;
        }

        public bool updateMessage(Communication com)
        {
            var parameter = new DynamicParameters();
            parameter.Add("idofMessage", com.id, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            parameter.Add("from1", com.Message_From, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("Message", com.The_Message, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("sdate", com.sent_date, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            parameter.Add("rid", com.reciver_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("sid", com.sent_id, dbType: DbType.Int32, direction: ParameterDirection.Input);



            dbContext.dbConnection.ExecuteAsync("Communication_package_api.insertMessage", parameter, commandType: CommandType.StoredProcedure);

            return true;
        }
    }
}
