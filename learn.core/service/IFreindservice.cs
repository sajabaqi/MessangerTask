using learn.core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.core.service
{
    public interface IFreindservice
    {
        public List<Freind_List> getallFreinds();
        public bool updateFreinds(Freind_List FL);
        public bool deleteFreinds(int id);
        public bool insertFreinds(Freind_List FL);
        public Freind_List getbyidFreinds(int id);
    }
}
