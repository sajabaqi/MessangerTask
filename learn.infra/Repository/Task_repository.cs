using Dapper;
using learn.core.Data;
using learn.core.domian;
using learn.core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace learn.infra.Repository
{
    public class Task_repository : ITask_repository
    {
        private readonly IDBcontext dbContext;
        public Task_repository(IDBcontext dbContext)
        {
            this.dbContext = dbContext;
        }

        public bool deletetask(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("idoftask", id, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            dbContext.dbConnection.Execute("Task_package_api.deletetask", parameter, commandType: CommandType.StoredProcedure);
            return true;
        }

        public List<Task_api> getalltask()
        {
            IEnumerable<Task_api> result = dbContext.dbConnection.Query<Task_api>("Task_package_api.getalltask", commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

        public Task_api getbyidtask(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("idoftask", id, dbType: DbType.Decimal, direction: ParameterDirection.Input);

            IEnumerable<Task_api> result = dbContext.dbConnection.Query<Task_api>("Task_package_api.getbyidtask", parameter, commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }

        public bool inserttask(Task_api task)
        {
            var parameter = new DynamicParameters();
            parameter.Add("idoftask", task.taskId, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            parameter.Add("Desc1", task.Descriptions, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("Hour1", task.hourtask, dbType: DbType.String, direction: ParameterDirection.Input);

            dbContext.dbConnection.ExecuteAsync("Task_package_api.inserttask", parameter, commandType: CommandType.StoredProcedure);

            return true;
        }

        public bool updatetask(Task_api task)
        {
            var parameter = new DynamicParameters();
            parameter.Add("idoftask", task.taskId, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            parameter.Add("Desc1", task.Descriptions, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("Hour1", task.hourtask, dbType: DbType.String, direction: ParameterDirection.Input);

            dbContext.dbConnection.ExecuteAsync("Task_package_api.updatetask", parameter, commandType: CommandType.StoredProcedure);

            return true;
        }
    }
}
