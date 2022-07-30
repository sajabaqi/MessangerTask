using learn.core.Data;
using learn.core.Repository;
using learn.core.service;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.infra.service
{
    public class Departmentservice : IDepartmentservice
    {
        private readonly IDepartment_repository department_Repository;
        public Departmentservice(IDepartment_repository department_Repository)
        {
            this.department_Repository = department_Repository;
        }
        public bool deletedep(int id)
        {
            return department_Repository.deletedep(id);
        }

        public List<Department_api> getalldep()
        {
            return department_Repository.getalldep();
        }

        public Department_api getbyid(int id)
        {
            return department_Repository.getbyid(id);
        }

        public bool insertdep(Department_api department)
        {
            return department_Repository.insertdep(department);
        }

        public bool updatedep(Department_api department)
        {
            return department_Repository.updatedep(department);
        }
    }
}
