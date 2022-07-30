using learn.core.Data;
using learn.core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.core.service
{
    public interface IEmployeeservice
    {
        public List<Employee1_api> getallemp();
        public bool updateemp(Employee1_api employee);
        public bool deleteemp(int id);
        public bool insertemp(Employee1_api employee);
        public Employee1_api getbyidemp(int id);
        public List<Emp_dto> getfull();
        public List<Task_dto> gettask();
        public int countOfEmployee();
        public string Sum();
        public string Avg();
        public string All();
        public string Checkemail(string email);
        public List<eachDep_dto> eachdep();
        public List<eachtasks_dto> geteachtask();
        public List<Check_dto> checkemail();
        public List<Check_dto> checkemailor();
        public List<Employee1_api> Filtername(char c);
        public List<Filterdate_dto> getbyfiltering(Checking1 Filterdate);
        public List<gettask_dto> gettaskid(int id);

    }
}
