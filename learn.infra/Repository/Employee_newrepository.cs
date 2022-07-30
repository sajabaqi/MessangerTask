using Dapper;
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
    public class Employee_newrepository : IEmployee_apinewrepository
    {
        private readonly IDBcontext dbContext;

        public Employee_newrepository(IDBcontext dbContext)
        {
            this.dbContext = dbContext;
        }
        public bool Exist(Employee_newDto employee_New)
        {
            var parameter = new DynamicParameters();
            parameter.Add("emailof", employee_New.email, dbType: DbType.String, direction: ParameterDirection.Input);

            IEnumerable<Employee_newDto> result = dbContext.dbConnection.Query<Employee_newDto>("Employee_apinew_package.Exist", parameter, commandType: CommandType.StoredProcedure);

            if(result == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool Exist1(BlockF_dto Block)
        {
            var parameter = new DynamicParameters();
            parameter.Add("E_mail", Block.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("MemState", Block.MemState, dbType: DbType.String, direction: ParameterDirection.Input);

            IEnumerable<BlockF_dto> result = dbContext.dbConnection.Query<BlockF_dto>("Users_package_api.BlockF", parameter, commandType: CommandType.StoredProcedure);

            if(result == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool Verify1(Employee_newDto employee_New)
        {
            var parameter = new DynamicParameters();
            parameter.Add("Verf", employee_New.Verfication_code, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("emailof", employee_New.email, dbType: DbType.String, direction: ParameterDirection.Input);            

            dbContext.dbConnection.ExecuteAsync("Employee_apinew_package.Verify1", parameter, commandType: CommandType.StoredProcedure);

            return true;
        }
    }
}
