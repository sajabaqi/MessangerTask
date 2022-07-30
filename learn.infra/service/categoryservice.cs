using learn.core.Data;
using learn.core.Repository;
using learn.core.service;
using learn.infra.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.infra.service
{
    public class categoryservice : Icategoryservice
    {
        private readonly ICategory_apirepository category_Apirepository;
        public categoryservice(ICategory_apirepository category_Apirepository)
        {
            this.category_Apirepository = category_Apirepository;
        }
        public bool deletecat(int id)
        {
            return category_Apirepository.deletecat(id);
        }

        public List<categorey_api> getallcat()
        {
            return category_Apirepository.getallcat();
        }

        public categorey_api getbyid(int id)
        {
            return category_Apirepository.getbyid(id);
        }

        public bool insertcat(categorey_api categorey)
        {
            return category_Apirepository.insertcat(categorey);
        }

        public bool updatecat(categorey_api categorey)
        {
            return category_Apirepository.updatecat(categorey);
        }
    }
}
