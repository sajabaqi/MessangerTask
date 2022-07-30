﻿using learn.core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.core.service
{
    public interface IDepartmentservice
    {
        public List<Department_api> getalldep();

        public bool insertdep(Department_api department);

        public bool deletedep(int id);

        public bool updatedep(Department_api department);

        public Department_api getbyid(int id);
    }
}
