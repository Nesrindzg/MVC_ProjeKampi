﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class MessageManager : IMessageService
    {
        IMessageDAL _messageDAL;

        public MessageManager(IMessageDAL MessageDAL)
        {
            _messageDAL = MessageDAL;
        }

        public void AddMessage(Message Message)
        {
            _messageDAL.Insert(Message);
        }

        public void DeleteMessage(Message Message)
        {
            _messageDAL.Delete(Message);
        }

        public Message GetById(int id)
        {
            return _messageDAL.Get(x => x.MessageID == id);
        }

        public List<Message> GetList(string p)
        {
            return _messageDAL.List(x => x.MessageContent == p);
        }

        public List<Message> GetListInbox(string mail, string p)
        {
            return _messageDAL.List(x => x.ReceiverMail == mail && x.MessageContent.Contains(p));
        }
        public List<Message> GetListSendbox(string mail, string p)
        {
            return _messageDAL.List(x => x.SenderMail == mail && x.MessageContent.Contains(p));
        }

        public void UpdateMessage(Message Message)
        {
            _messageDAL.Update(Message);
        }
    }
}
