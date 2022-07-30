using learn.core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.core.service
{
    public interface ITaskservice
    {
        public List<Task_api> getalltask();
        public bool updatetask(Task_api task);
        public bool deletetask(int id);
        public bool inserttask(Task_api task);
        public Task_api getbyidtask(int id);
    }
}
