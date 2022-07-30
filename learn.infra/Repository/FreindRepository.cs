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
    public class FreindRepository : IFreind_Repository
    {
        private readonly IDBcontext dbContext;
        public FreindRepository(IDBcontext dbContext)
        {
            this.dbContext = dbContext;
        }

        public bool deleteFreinds(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("idofFreind", id, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            dbContext.dbConnection.Execute("Freind_package_api.deleteFreinds", parameter, commandType: CommandType.StoredProcedure);
            return true;
        }

        public List<Freind_List> getallFreinds()
        {
            IEnumerable<Freind_List> result = dbContext.dbConnection.Query<Freind_List>("Freind_package_api.getallFreinds", commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

        public Freind_List getbyidFreinds(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("idofFreind", id, dbType: DbType.Decimal, direction: ParameterDirection.Input);

            IEnumerable<Freind_List> result = dbContext.dbConnection.Query<Freind_List>("Freind_package_api.getbyidFreinds", parameter, commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }

        public bool insertFreinds(Freind_List FL)
        {
            var parameter = new DynamicParameters();
            parameter.Add("idofFreind", FL.id, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            parameter.Add("Ufr", FL.User_fr, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("FWith", FL.Freind_with, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("F_statue", FL.Freind_statue, dbType: DbType.String, direction: ParameterDirection.Input);

            dbContext.dbConnection.ExecuteAsync("Freind_package_api.insertFreinds", parameter, commandType: CommandType.StoredProcedure);

            return true;
        }

        public bool updateFreinds(Freind_List FL)
        {
            var parameter = new DynamicParameters();
            parameter.Add("idofFreind", FL.id, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            parameter.Add("Ufr", FL.User_fr, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("FWith", FL.Freind_with, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("F_statue", FL.Freind_statue, dbType: DbType.String, direction: ParameterDirection.Input);

            dbContext.dbConnection.ExecuteAsync("Freind_package_api.updateFreinds", parameter, commandType: CommandType.StoredProcedure);

            return true;
        }
    }
}
