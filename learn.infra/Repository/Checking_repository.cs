using Dapper;
using learn.core.Data;
using learn.core.domian;
using learn.core.DTO;
using learn.core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;


namespace learn.infra.Repository
{
    public class Checking_repository : IChecking_repository
    {
        private readonly IDBcontext dbContext;
        public Checking_repository(IDBcontext dbContext)
        {
            this.dbContext = dbContext;
        }

        public bool deletech(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("idofch", id, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            dbContext.dbConnection.Execute("Checking1_package_api.deletech", parameter, commandType: CommandType.StoredProcedure);
            return true;
        }

        public List<Checking1> getallch()
        {
            IEnumerable<Checking1> result = dbContext.dbConnection.Query<Checking1>("Checking1_package_api.getallch", commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

        public Checking1 getbyidch(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("idofch", id, dbType: DbType.Decimal, direction: ParameterDirection.Input);

            IEnumerable<Checking1> result = dbContext.dbConnection.Query<Checking1>("Checking1_package_api.getbyidch", parameter, commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }

        public List<Salary> getbyfiltering(Filterdate_dto emp)
        {
            var parameter = new DynamicParameters();
            parameter.Add("startdate", emp.startdate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            parameter.Add("enddate", emp.enddate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            IEnumerable<Salary> result = dbContext.dbConnection.Query<Salary>("Checking1_package_api.getbyfiltering", parameter, commandType: System.Data.CommandType.StoredProcedure);

            return result.ToList();


        }

        public bool insertch(Checking1 checking)
        {
            var parameter = new DynamicParameters();
            parameter.Add("idofch", checking.id, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            parameter.Add("Cin", checking.Checkin, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            parameter.Add("Cout", checking.Checkout, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            parameter.Add("employeeid", checking.empid, dbType: DbType.Decimal, direction: ParameterDirection.Input);


            dbContext.dbConnection.ExecuteAsync("Checking1_package_api.insertch", parameter, commandType: CommandType.StoredProcedure);

            return true;
        }

        public bool updatech(Checking1 checking)
        {
            var parameter = new DynamicParameters();
            parameter.Add("idofch", checking.id, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            parameter.Add("Cin", checking.Checkin, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            parameter.Add("Cout", checking.Checkout, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            parameter.Add("employeeid", checking.empid, dbType: DbType.Decimal, direction: ParameterDirection.Input);


            dbContext.dbConnection.ExecuteAsync("Checking1_package_api.insertch", parameter, commandType: CommandType.StoredProcedure);

            return true;
        }
    }
}
