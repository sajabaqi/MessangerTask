using learn.core.Data;
using learn.core.Repository;
using learn.core.service;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.infra.service
{
    public class GroupsAddservice : IGroupAddservice
    {
        private readonly IGroupAddRepository groupAddRepository;
        public GroupsAddservice(IGroupAddRepository groupAddRepository)
        {
            this.groupAddRepository = groupAddRepository;
        }

        public bool deleteGroupAdd(int id)
        {
            return groupAddRepository.deleteGroupAdd(id);
        }

        public List<Groups_Add> getallGroupAdd()
        {
            return groupAddRepository.getallGroupAdd();
        }

        public Groups_Add getbyidGroupAdd(int id)
        {
            return groupAddRepository.getbyidGroupAdd(id);
        }

        public bool insertGroupAdd(Groups_Add GA)
        {
            return groupAddRepository.insertGroupAdd(GA);
        }

        public bool updateGroupAdd(Groups_Add GA)
        {
            return groupAddRepository.updateGroupAdd(GA);
        }
    }
}
