using learn.core.Data;
using learn.core.Repository;
using learn.core.service;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.infra.service
{
    public class ServiceService : IserviceService
    {
        private readonly IserviceRepository iserviceRepository;
        public ServiceService(IserviceRepository iserviceRepository)
        {
            this.iserviceRepository = iserviceRepository;
        }

        public bool deleteService(int id)
        {
            return iserviceRepository.deleteService(id);
        }

        public List<Service_api> getallService()
        {
            return iserviceRepository.getallService();
        }

        public Service_api getbyidService(int id)
        {
            return iserviceRepository.getbyidService(id);
        }

        public bool insertService(Service_api service_)
        {
            return iserviceRepository.insertService(service_);
        }

        public bool updateService(Service_api service_)
        {
            return iserviceRepository.updateService(service_);
        }
    }
}
