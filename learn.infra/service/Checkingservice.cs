using learn.core.Data;
using learn.core.DTO;
using learn.core.Repository;
using learn.core.service;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.infra.service
{
    public class Checkingservice : ICheckingservice
    {
        private readonly IChecking_repository checking_repository;
        public Checkingservice(IChecking_repository checking_repository)
        {
            this.checking_repository = checking_repository;
        }

        public bool deletech(int id)
        {
            return checking_repository.deletech(id);
        }

        public List<Checking1> getallch()
        {
            return checking_repository.getallch();
        }

        public Checking1 getbyidch(int id)
        {
            return checking_repository.getbyidch(id);
        }

        public List<Salary> getbyfiltering(Filterdate_dto emp)
        {
            return checking_repository.getbyfiltering(emp);
        }

        public bool insertch(Checking1 checking)
        {
            return checking_repository.insertch(checking);
        }

        public bool updatech(Checking1 checking)
        {
            return checking_repository.updatech(checking);
        }
    }
}
