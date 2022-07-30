using learn.core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.core.Repository
{
    public interface IAuthentication
    {
        public login_api auth(login_api login);
    }
}
