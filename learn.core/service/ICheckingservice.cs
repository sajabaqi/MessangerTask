using learn.core.Data;
using learn.core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.core.service
{
    public interface ICheckingservice
    {
        public List<Checking1> getallch();
        public bool updatech(Checking1 checking);
        public bool deletech(int id);
        public bool insertch(Checking1 checking);
        public Checking1 getbyidch(int id);
        public List<Salary> getbyfiltering(Filterdate_dto emp);

    }
}
