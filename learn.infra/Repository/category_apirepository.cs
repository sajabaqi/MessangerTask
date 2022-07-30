using Dapper;
using learn.core.Data;
using learn.core.domian;
using learn.core.Repository;
using learn.infra.domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace learn.infra.Repository
{
    public class category_apirepository : ICategory_apirepository
    {
        private readonly IDBcontext dbContext;
        public category_apirepository(IDBcontext dbContext)
        {
            this.dbContext = dbContext;
        }
        public bool deletecat(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("idofcat", id, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            dbContext.dbConnection.Execute("category_package_api.deletecat", parameter, commandType: CommandType.StoredProcedure);
            return true;

        }

        public List<categorey_api> getallcat()
        {
            IEnumerable<categorey_api> result = dbContext.dbConnection.Query<categorey_api>("category_package_api.getallcat", commandType: CommandType.StoredProcedure);

            return result.ToList();
            //IEnumerable<categorey_api> result = dbContext.dbConnection.Query<categorey_api>("categorey_package_api.getallcat", commandType: CommandType.StoredProcedure);

            //return result.ToList();
        }

        public categorey_api getbyid(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("idofcat", id, dbType: DbType.Decimal, direction: ParameterDirection.Input);

            IEnumerable<categorey_api> result = dbContext.dbConnection.Query<categorey_api>("category_package_api.getbyid", parameter,commandType:CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }

        public bool insertcat(categorey_api categorey)
        {
            var parameter = new DynamicParameters();
            parameter.Add("idofcat", categorey.id, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            parameter.Add("categoryname", categorey.catname, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("categorydate", categorey.catdate, dbType: DbType.DateTime, direction: ParameterDirection.Input);

            dbContext.dbConnection.ExecuteAsync("category_package_api.insertcat", parameter, commandType: CommandType.StoredProcedure);

            return true;
        }

        public bool updatecat(categorey_api categorey)
        {
            var parameter = new DynamicParameters();
            parameter.Add("idofcat", categorey.id, dbType: DbType.Decimal, direction: ParameterDirection.Input);

            parameter.Add("categoryname", categorey.catname, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("categorydate", categorey.catdate, dbType: DbType.DateTime, direction: ParameterDirection.Input);

            dbContext.dbConnection.ExecuteAsync("category_package_api.updatecat", parameter, commandType: CommandType.StoredProcedure);

            return true;
        }

        //bool ICategory_apirepository.insertcat(categorey_api categorey)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
