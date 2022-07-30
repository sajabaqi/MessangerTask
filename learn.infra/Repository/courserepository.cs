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
    public class courserepository : ICourserepository
    {
        private readonly IDBcontext dbContext;

        public courserepository(IDBcontext dbContext)
        {
            this.dbContext = dbContext;
        }
        public bool deletecourse(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("idofcourse", id, dbType: DbType.Int32, direction: ParameterDirection.Input);


            var result = dbContext.dbConnection.ExecuteAsync("course1_package_api.deletecourse", parameter, commandType: CommandType.StoredProcedure);
            if (result == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public List<course1_api> getallcourse()
        {
            IEnumerable<course1_api> result = dbContext.dbConnection.Query<course1_api>("course1_package_api.getallcourse", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public bool createinsertcourse(course1_api course)
        {
            var parameter = new DynamicParameters();
            parameter.Add("idofcourse", course.id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("nameofcourse", course.coursename, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("Price", course.courseprice, dbType: DbType.Int32, direction: ParameterDirection.Input);

            dbContext.dbConnection.ExecuteAsync("course1_package_api.createinsertcourse", parameter, commandType: CommandType.StoredProcedure);

            return true;
        }

        public double Price()
        {
            List<course1_api> c = getallcourse();
            double sum = 0;
            for (int i = 0; i < c.Count; i++)
            {
                sum += (double) c[i].courseprice;
            }
            return sum;
        }

        public List<course1_api> Lastrecords()
        {
            List<course1_api> c = getallcourse();
            var d = c.OrderBy(x => x.id).ToList();
            List<course1_api> cc = new List<course1_api>();
            cc.Add(d[d.Count - 1]);
            cc.Add(d[d.Count - 2]);
            return cc.ToList();
        }

        public List<course1_api> Orderby()
        {
            List<course1_api> c = getallcourse();
            return c.OrderByDescending(x => x.id).ToList();
        }
    }
}
