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
    public class Authentication : IAuthentication
    {
        private readonly IDBcontext dBContext;
        public Authentication(IDBcontext dBContext)
        {
            this.dBContext = dBContext;
        }

        public login_api auth(login_api login)
        {
            
            var parameter = new DynamicParameters();
            parameter.Add("username1", login.username, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("password1", login.password, dbType: DbType.String, direction: ParameterDirection.Input);

            IEnumerable<login_api> result = dBContext.dbConnection.Query<login_api>("loginapi_package.Auth", parameter, commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }
    }
}
