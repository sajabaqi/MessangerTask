using learn.core.Data;
using learn.core.Repository;
using learn.core.service;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.infra.service
{
    public class Taskservice : ITaskservice
    {
        private readonly ITask_repository task_repository;
        public Taskservice(ITask_repository task_repository)
        {
            this.task_repository = task_repository;
        }

        public bool deletetask(int id)
        {
            return task_repository.deletetask(id);
        }

        public List<Task_api> getalltask()
        {
            return task_repository.getalltask();
        }

        public Task_api getbyidtask(int id)
        {
            return task_repository.getbyidtask(id);
        }

        public bool inserttask(Task_api task)
        {
            return task_repository.inserttask(task);
        }

        public bool updatetask(Task_api task)
        {
            return task_repository.updatetask(task);
        }
    }
}
