using learn.core.Data;
using learn.core.Repository;
using learn.core.service;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.infra.service
{
    public class Taskempservice :ITaskempservice
    {
        private readonly ITaskemp_repository taskemp_repository;
        public Taskempservice(ITaskemp_repository taskemp_repository)
        {
            this.taskemp_repository = taskemp_repository;
        }

        public bool deletetaskemp(int id)
        {
            return taskemp_repository.deletetaskemp(id);
        }

        public List<Taskemp_api> getalltaskemp()
        {
            return taskemp_repository.getalltaskemp();
        }

        public Taskemp_api getbyidtaskemp(int id)
        {
            return taskemp_repository.getbyidtaskemp(id);
        }

        public bool inserttaskemp(Taskemp_api taskemp)
        {
            return taskemp_repository.inserttaskemp(taskemp);
        }

        public bool updatetaskemp(Taskemp_api taskemp)
        {
            return taskemp_repository.updatetaskemp(taskemp);
        }
    }
}
