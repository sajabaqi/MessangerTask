using learn.core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.core.service
{
    public interface IGroupAddservice
    {
        public List<Groups_Add> getallGroupAdd();
        public bool updateGroupAdd(Groups_Add GA);
        public bool deleteGroupAdd(int id);
        public bool insertGroupAdd(Groups_Add GA);
        public Groups_Add getbyidGroupAdd(int id);
    }
}
