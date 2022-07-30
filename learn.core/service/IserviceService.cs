using learn.core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.core.service
{
    public interface IserviceService
    {
        public List<Service_api> getallService();
        public bool updateService(Service_api service_);
        public bool deleteService(int id);
        public bool insertService(Service_api service_);
        public Service_api getbyidService(int id);
    }
}
