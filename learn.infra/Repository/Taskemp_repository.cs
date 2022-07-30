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
    public class Taskemp_repository : ITaskemp_repository
    {
        private readonly IDBcontext dbContext;
        public Taskemp_repository(IDBcontext dbContext)
        {
            this.dbContext = dbContext;
        }

        public bool deletetaskemp(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("idoftaskemp", id, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            dbContext.dbConnection.Execute("Taskemp_package_api.deletetaskemp", parameter, commandType: CommandType.StoredProcedure);
            return true;
        }

        public List<Taskemp_api> getalltaskemp()
        {
            IEnumerable<Taskemp_api> result = dbContext.dbConnection.Query<Taskemp_api>("Taskemp_package_api.getalltaskemp", commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

        public Taskemp_api getbyidtaskemp(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("idoftaskemp", id, dbType: DbType.Decimal, direction: ParameterDirection.Input);

            IEnumerable<Taskemp_api> result = dbContext.dbConnection.Query<Taskemp_api>("Taskemp_package_api.getbyidtaskemp", parameter, commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }

        public bool inserttaskemp(Taskemp_api taskemp)
        {
            var parameter = new DynamicParameters();
            parameter.Add("idoftaskemp", taskemp.taskempId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("Employeeid", taskemp.empid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("tid", taskemp.taskId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            dbContext.dbConnection.ExecuteAsync("Taskemp_package_api.inserttaskemp", parameter, commandType: CommandType.StoredProcedure);

            return true;
        }

        public bool updatetaskemp(Taskemp_api taskemp)
        {
            var parameter = new DynamicParameters();
            parameter.Add("idoftaskemp", taskemp.taskempId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("Employeeid", taskemp.empid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("tid", taskemp.taskId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            dbContext.dbConnection.ExecuteAsync("Taskemp_package_api.updatetaskemp", parameter, commandType: CommandType.StoredProcedure);

            return true;
        }
    }
}
