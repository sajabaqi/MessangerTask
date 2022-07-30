using learn.core.Data;
using learn.core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.core.service
{
    public interface IAuthenticationservice
    {
        public string Authentication_jwt(login_api login);
        public string Authentication_jwt(BlockF_dto BlockF_);
    }
}
