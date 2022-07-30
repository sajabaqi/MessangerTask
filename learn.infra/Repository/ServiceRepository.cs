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
    public class ServiceRepository : IserviceRepository
    {
        private readonly IDBcontext dbContext;
        public ServiceRepository(IDBcontext dbContext)
        {
            this.dbContext = dbContext;
        }

        public bool deleteService(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("idofService", id, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            dbContext.dbConnection.Execute("Service_package_api.deleteService", parameter, commandType: CommandType.StoredProcedure);
            return true;
        }

        public List<Service_api> getallService()
        {
            IEnumerable<Service_api> result = dbContext.dbConnection.Query<Service_api>("Service_package_api.getallService", commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

        public Service_api getbyidService(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("idofService", id, dbType: DbType.Decimal, direction: ParameterDirection.Input);

            IEnumerable<Service_api> result = dbContext.dbConnection.Query<Service_api>("Service_package_api.getbyidService", parameter, commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }

        public bool insertService(Service_api service_)
        {
            var parameter = new DynamicParameters();
            parameter.Add("idofService", service_.id, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            parameter.Add("Sname", service_.ServiceName, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("Cid", service_.catid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("P", service_.Price, dbType: DbType.Double, direction: ParameterDirection.Input);
            parameter.Add("Ldate", service_.LiveDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);            
            parameter.Add("Uid", service_.UserIid, dbType: DbType.Int32, direction: ParameterDirection.Input);

            dbContext.dbConnection.ExecuteAsync("Service_package_api.insertService", parameter, commandType: CommandType.StoredProcedure);

            return true;
        }

        public bool updateService(Service_api service_)
        {
            var parameter = new DynamicParameters();
            parameter.Add("idofService", service_.id, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            parameter.Add("Sname", service_.ServiceName, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("Cid", service_.catid, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            parameter.Add("Ldate", service_.LiveDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            parameter.Add("P", service_.Price, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("Uid", service_.UserIid, dbType: DbType.Int32, direction: ParameterDirection.Input);

            dbContext.dbConnection.ExecuteAsync("Service_package_api.updateService", parameter, commandType: CommandType.StoredProcedure);

            return true;
        }
    }
}
