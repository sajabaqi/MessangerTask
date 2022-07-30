using learn.core.Data;
using learn.core.DTO;
using learn.core.Repository;
using learn.core.service;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.infra.service
{
    public class Employeeservice : IEmployeeservice
    {
        private readonly IEmployee_repository employeerepository;
        public Employeeservice(IEmployee_repository employeerepository)
        {
            this.employeerepository = employeerepository;
        }

        public string All()
        {
            return employeerepository.All();
        }

        public string Avg()
        {
            return employeerepository.Avg();
        }

        public string Checkemail(string email)
        {
            return employeerepository.Checkemail(email);
        }

        public List<Check_dto> checkemail()
        {
            return employeerepository.checkemail();
        }

        public List<Check_dto> checkemailor()
        {
            return employeerepository.checkemailor();
        }

        public int countOfEmployee()
        {
            return employeerepository.countOfEmployee();
        }

        public bool deleteemp(int id)
        {
            return employeerepository.deleteemp(id);
        }

        public List<eachDep_dto> eachdep()
        {
            return employeerepository.eachdep();
        }

        public List<Employee1_api> Filtername(char c)
        {
            return employeerepository.Filtername(c);
        }

        public List<Employee1_api> getallemp()
        {
            return employeerepository.getallemp();
        }

        public List<Filterdate_dto> getbyfiltering(Checking1 Filterdate)
        {
            return employeerepository.getbyfiltering(Filterdate);
        }

        public Employee1_api getbyidemp(int id)
        {
            return employeerepository.getbyidemp(id);
        }

        public List<eachtasks_dto> geteachtask()
        {
            return employeerepository.geteachtask();
        }

        public List<Emp_dto> getfull()
        {
            return employeerepository.getfull();
        }
        public List<Task_dto> gettask()
        {
            return employeerepository.gettask();
        }

        public List<gettask_dto> gettaskid(int id)
        {
            return employeerepository.gettaskid(id);
        }

        public bool insertemp(Employee1_api employee)
        {
            return employeerepository.insertemp(employee);
        }

        public string Sum()
        {
            return employeerepository.Sum();
        }

        public bool updateemp(Employee1_api employee)
        {
            return employeerepository.updateemp(employee);
        }
    }
}
