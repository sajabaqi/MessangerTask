using learn.core.Data;
using learn.core.Repository;
using learn.core.service;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.infra.service
{
    public class Freindservice : IFreindservice
    {
        private readonly IFreind_Repository freind_Repository;
        public Freindservice(IFreind_Repository freind_Repository)
        {
            this.freind_Repository = freind_Repository;
        }

        public bool deleteFreinds(int id)
        {
            return freind_Repository.deleteFreinds(id);
        }

        public List<Freind_List> getallFreinds()
        {
            return freind_Repository.getallFreinds();
        }

        public Freind_List getbyidFreinds(int id)
        {
            return freind_Repository.getbyidFreinds(id);
        }

        public bool insertFreinds(Freind_List FL)
        {
            return freind_Repository.insertFreinds(FL);
        }

        public bool updateFreinds(Freind_List FL)
        {
            return freind_Repository.updateFreinds(FL);
        }
    }
}
