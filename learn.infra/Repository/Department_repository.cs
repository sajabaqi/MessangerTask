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
    public class Department_repository : IDepartment_repository
    {
        private readonly IDBcontext dbContext;
        public Department_repository(IDBcontext dbContext)
        {
            this.dbContext = dbContext;
        }
        public bool deletedep(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("idofdep", id, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            dbContext.dbConnection.Execute("Department_package_api.deletedep", parameter, commandType: CommandType.StoredProcedure);
            return true;
        }

        public List<Department_api> getalldep()
        {
            IEnumerable<Department_api> result = dbContext.dbConnection.Query<Department_api>("Department_package_api.getalldep", commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

        public Department_api getbyid(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("idofdep", id, dbType: DbType.Decimal, direction: ParameterDirection.Input);

            IEnumerable<Department_api> result = dbContext.dbConnection.Query<Department_api>("Department_package_api.getbyid", parameter, commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }

        public bool insertdep(Department_api department)
        {
            var parameter = new DynamicParameters();
            parameter.Add("idofdep", department.id, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            parameter.Add("Departmentname", department.Dname, dbType: DbType.String, direction: ParameterDirection.Input);

            dbContext.dbConnection.ExecuteAsync("Department_package_api.insertdep", parameter, commandType: CommandType.StoredProcedure);

            return true;
        }

        public bool updatedep(Department_api department)
        {
            var parameter = new DynamicParameters();
            parameter.Add("idofdep", department.id, dbType: DbType.Decimal, direction: ParameterDirection.Input);

            parameter.Add("Departmentname", department.Dname, dbType: DbType.String, direction: ParameterDirection.Input);

            dbContext.dbConnection.ExecuteAsync("Department_package_api.updatedep", parameter, commandType: CommandType.StoredProcedure);

            return true;
        }
    }
}
