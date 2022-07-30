using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace learn.core.domian
{
    public interface IDBcontext
    {
        public DbConnection dbConnection { get;  }
    }
}
