using learn.core.Data;
using learn.core.Repository;
using learn.core.service;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.infra.service
{
    public class GroupCreateservice : IGroupservice
    {
        private readonly GCreate_repository gCreate_Repository;
        public GroupCreateservice(GCreate_repository gCreate_Repository)
        {
            this.gCreate_Repository = gCreate_Repository;
        }

        public bool deleteGroups(int id)
        {
            return gCreate_Repository.deleteGroups(id);
        }

        public List<Group_Create> getallGroups()
        {
            return gCreate_Repository.getallGroups();
        }

        public Group_Create getbyidGroups(int id)
        {
            return gCreate_Repository.getbyidGroups(id);
        }

        public bool insertGroups(Group_Create group_Create)
        {
            return gCreate_Repository.insertGroups(group_Create);
        }

        public bool updateGroups(Group_Create group_Create)
        {
            return gCreate_Repository.updateGroups(group_Create);
        }
    }
}
