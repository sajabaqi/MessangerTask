﻿using learn.core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.core.Repository
{
    public interface ICategory_apirepository
    {
        public List<categorey_api> getallcat();
        public bool updatecat(categorey_api categorey);
        public bool deletecat(int id);
        public bool insertcat(categorey_api categorey);
        public categorey_api getbyid(int id);
    }
}
