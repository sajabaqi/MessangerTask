using learn.core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.core.Repository
{
    public interface IEmployee_apinewrepository
    {
        public bool Exist(Employee_newDto employee_New);
        public bool Exist1(BlockF_dto Block);
        public bool Verify1(Employee_newDto employee_New);
        //public bool Verify1(Employee_newDto employee_New);
    }
}
