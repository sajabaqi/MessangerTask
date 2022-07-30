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
    public class Employee_repository : IEmployee_repository
    {
        private readonly IDBcontext dbContext;
        public Employee_repository(IDBcontext dbContext)
        {
            this.dbContext = dbContext;
        }

        public string All()
        {
            List<Employee1_api> c = getallemp();
            double s = 0;

            for (int i = 0; i < c.Count; i++)
            {
                s += c[i].Salary;
            }
            
            return "Salary: " + s+ "  Avg: "+s/c.Count+ "   Count : "+c.Count;
        }

        public string Avg()
        {
            List<Employee1_api> c = getallemp();
            double s = 0;

            for (int i = 0; i < c.Count; i++)
            {
                s += c[i].Salary;
            }
             
            return  "Avg: " + s/c.Count;
        }

        public string Checkemail(string email)
        {
            List<Employee1_api> cc = getallemp();
            List<Employee1_api> ccc = new List<Employee1_api>();
            for (int i = 0; i < cc.Count; i++)
            {
                if (email == cc[i].Email)
                {
                    return "Exist";
                }

            }
            return "not Exist";
        }
        //.com
        public List<Check_dto> checkemail()
        {
            IEnumerable<Check_dto> result = dbContext.dbConnection.Query<Check_dto>("Employee1_package_api.checkemail", commandType: CommandType.StoredProcedure);

            return result.ToList();
        }
        //Exist
        public List<Check_dto> checkemailor()
        {
            IEnumerable<Check_dto> result = dbContext.dbConnection.Query<Check_dto>("Employee1_package_api.checkemail", commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

        public int countOfEmployee()
        {
            List<Employee1_api> c = getallemp();

            return c.Count;
        }
        public bool deleteemp(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("idofemp", id, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            dbContext.dbConnection.Execute("Employee1_package_api.deleteemp", parameter, commandType: CommandType.StoredProcedure);
            return true;
        }

        public List<eachDep_dto> eachdep()
        {
            IEnumerable<eachDep_dto> result = dbContext.dbConnection.Query<eachDep_dto>("Employee1_package_api.eachdep", commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

            public List<Employee1_api> Filtername(char c)
            {
                List<Employee1_api> cc = getallemp();
                List<Employee1_api> ccc = new List<Employee1_api>();
                for (int i = 0; i < cc.Count; i++)
                {
                    for (int k = 0; k < cc[i].Fname.Length; k++)
                    {
                        if (cc[i].Fname[k] == c)
                        {
                            ccc.Add(cc[i]);
                            break;
                        }

                    }
                }
                return ccc.ToList();


            }
        

        public List<Employee1_api> getallemp()
        {
            IEnumerable<Employee1_api> result = dbContext.dbConnection.Query<Employee1_api>("Employee1_package_api.getallemp", commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

        public List<Filterdate_dto> getbyfiltering(Checking1 Filterdate)
        {
            var parameter = new DynamicParameters();
            parameter.Add("startdate", Filterdate.Checkin, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            parameter.Add("enddate", Filterdate.Checkout, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            IEnumerable<Filterdate_dto> result = dbContext.dbConnection.Query<Filterdate_dto>("Employee1_package_api.getbyfiltering", commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

        public Employee1_api getbyidemp(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("idofemp", id, dbType: DbType.Decimal, direction: ParameterDirection.Input);

            IEnumerable<Employee1_api> result = dbContext.dbConnection.Query<Employee1_api>("Employee1_package_api.getbyidemp", parameter, commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }

        public List<gettask_dto> gettaskid(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("idofemp", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            

            IEnumerable<gettask_dto> result = dbContext.dbConnection.Query<gettask_dto>("Employee1_package_api.gettaskid", parameter, commandType: CommandType.StoredProcedure);
            
            return result.ToList();
        }

        public List<eachtasks_dto> geteachtask()
        {
            IEnumerable<eachtasks_dto> result = dbContext.dbConnection.Query<eachtasks_dto>("Employee1_package_api.geteachtask", commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

        public List<Emp_dto> getfull()
        {
            IEnumerable<Emp_dto> result = dbContext.dbConnection.Query<Emp_dto>("Employee1_package_api.getfull", commandType: CommandType.StoredProcedure);

            return result.ToList();
        }
        public List<Task_dto> gettask()
        {
            IEnumerable<Task_dto> result = dbContext.dbConnection.Query<Task_dto>("Employee1_package_api.gettask", commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

        public bool insertemp(Employee1_api employee)
        {
            var parameter = new DynamicParameters();
            parameter.Add("idofemp", employee.id, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            parameter.Add("Firstname", employee.Fname, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("Lastname", employee.Lname, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("Salarypar", employee.Salary, dbType: DbType.Double, direction: ParameterDirection.Input);
            parameter.Add("Empemail", employee.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("DepartmentId", employee.DepId, dbType: DbType.Decimal, direction: ParameterDirection.Input);

            dbContext.dbConnection.ExecuteAsync("Employee1_package_api.insertemp", parameter, commandType: CommandType.StoredProcedure);

            return true;
        }

        public string Sum()
        {
            List<Employee1_api> c = getallemp();
            double s = 0;
            
            for (int i = 0; i < c.Count; i++)
            {
                s += c[i].Salary;
            }
            
            return "Salary: " + s ;
        }

        public bool updateemp(Employee1_api employee)
        {
            var parameter = new DynamicParameters();
            parameter.Add("Firstname", employee.Fname, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("Lastname", employee.Lname, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("Salarypar", employee.Salary, dbType: DbType.Double, direction: ParameterDirection.Input);
            parameter.Add("Empemail", employee.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("DepartmentId", employee.DepId, dbType: DbType.Decimal, direction: ParameterDirection.Input);

            var result = dbContext.dbConnection.ExecuteAsync("Employee1_package_api.insertemp", parameter, commandType: CommandType.StoredProcedure);
            if (result == null)
                return false;
            return true;
        }

    }
}
