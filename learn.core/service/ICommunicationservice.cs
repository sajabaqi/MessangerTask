using learn.core.Data;
using learn.core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.core.service
{
    public interface ICommunicationservice
    {
        public List<Communication> getallMessage();
        public bool updateMessage(Communication com);
        public bool deleteMessage(int id);
        public bool insertMessage(Communication com);
        public Communication getbyidMessage(int id);
        public int CountMessage();
        public List<Between_dto> getdateBetween(Between_dto between_);
    }
}
