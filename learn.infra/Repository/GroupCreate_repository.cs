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
    public class GroupCreate_repository : GCreate_repository
    {
        private readonly IDBcontext dbContext;
        public GroupCreate_repository(IDBcontext dbContext)
        {
            this.dbContext = dbContext;
        }

        public bool deleteGroups(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("idofGroups", id, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            dbContext.dbConnection.Execute("GroupCreate_package_api.deleteGroups", parameter, commandType: CommandType.StoredProcedure);
            return true;    
        }

        public List<Group_Create> getallGroups()
        {
            IEnumerable<Group_Create> result = dbContext.dbConnection.Query<Group_Create>("GroupCreate_package_api.getallGroups", commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

        public Group_Create getbyidGroups(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("idofGroups", id, dbType: DbType.Decimal, direction: ParameterDirection.Input);

            IEnumerable<Group_Create> result = dbContext.dbConnection.Query<Group_Create>("GroupCreate_package_api.getbyidGroups", parameter, commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }

        public bool insertGroups(Group_Create group_Create)
        {
            var parameter = new DynamicParameters();
            parameter.Add("idofGroups", group_Create.id, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            parameter.Add("Gname", group_Create.Group_name, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("cdate", group_Create.create_date, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            parameter.Add("uid", group_Create.user_id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            dbContext.dbConnection.ExecuteAsync("GroupCreate_package_api.insertGroups", parameter, commandType: CommandType.StoredProcedure);

            return true;
        }

        public bool updateGroups(Group_Create group_Create)
        {
            var parameter = new DynamicParameters();
            parameter.Add("idofGroups", group_Create.id, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            parameter.Add("Gname", group_Create.Group_name, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("cdate", group_Create.create_date, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            parameter.Add("uid", group_Create.user_id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            dbContext.dbConnection.ExecuteAsync("GroupCreate_package_api.updateGroups", parameter, commandType: CommandType.StoredProcedure);

            return true;
        }
    }
}
