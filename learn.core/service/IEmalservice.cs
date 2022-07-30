using learn.core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.core.service
{
    public interface IEmalservice
    {
        public string GetEmail(Employee_newDto e);
        public string BlockEmail(BlockF_dto BlockF_);
    }
}
