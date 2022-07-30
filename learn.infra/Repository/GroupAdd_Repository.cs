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
    public class GroupAdd_Repository : IGroupAddRepository
    {
        private readonly IDBcontext dbContext;
        public GroupAdd_Repository(IDBcontext dbContext)
        {
            this.dbContext = dbContext;
        }

        public bool deleteGroupAdd(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("idofGroupAdd", id, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            dbContext.dbConnection.Execute("GroupAdd_package_api.deleteGroupAdd", parameter, commandType: CommandType.StoredProcedure);
            return true;
        }

        public List<Groups_Add> getallGroupAdd()
        {
            IEnumerable<Groups_Add> result = dbContext.dbConnection.Query<Groups_Add>("GroupAdd_package_api.getallGroupAdd", commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

        public Groups_Add getbyidGroupAdd(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("idofGroupAdd", id, dbType: DbType.Decimal, direction: ParameterDirection.Input);

            IEnumerable<Groups_Add> result = dbContext.dbConnection.Query<Groups_Add>("GroupAdd_package_api.getbyidGroupAdd", parameter, commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }

        public bool insertGroupAdd(Groups_Add GA)
        {
            var parameter = new DynamicParameters();
            parameter.Add("idofGroupAdd", GA.id, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            parameter.Add("Adds", GA.Add_Member, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("M_statue", GA.Member_statue, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("Gid", GA.Group_CreateId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            dbContext.dbConnection.ExecuteAsync("GroupAdd_package_api.insertGroupAdd", parameter, commandType: CommandType.StoredProcedure);

            return true;
        }

        public bool updateGroupAdd(Groups_Add GA)
        {
            var parameter = new DynamicParameters();
            parameter.Add("idofGroupAdd", GA.id, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            parameter.Add("Adds", GA.Add_Member, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("M_statue", GA.Member_statue, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("Gid", GA.Group_CreateId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            dbContext.dbConnection.ExecuteAsync("GroupAdd_package_api.updateGroupAdd", parameter, commandType: CommandType.StoredProcedure);

            return true;
        }
    }
}
