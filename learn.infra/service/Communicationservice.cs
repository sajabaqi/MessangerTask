using learn.core.Data;
using learn.core.DTO;
using learn.core.Repository;
using learn.core.service;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.infra.service
{
    public class Communicationservice : ICommunicationservice
    {
        private readonly ICommunication_repository communicationrepository;
        public Communicationservice(ICommunication_repository communicationrepository)
        {
            this.communicationrepository = communicationrepository;
        }

        public int CountMessage()
        {
            return communicationrepository.CountMessage();
        }

        public bool deleteMessage(int id)
        {
            return communicationrepository.deleteMessage(id);
        }

        public List<Communication> getallMessage()
        {
            return communicationrepository.getallMessage();
        }

        public Communication getbyidMessage(int id)
        {
            return communicationrepository.getbyidMessage(id);
        }

        public List<Between_dto> getdateBetween(Between_dto between_)
        {
            return communicationrepository.getdateBetween(between_);
        }

        public bool insertMessage(Communication com)
        {
            return communicationrepository.insertMessage(com);
        }

        public bool updateMessage(Communication com)
        {
            return communicationrepository.updateMessage(com);
        }
    }
}
