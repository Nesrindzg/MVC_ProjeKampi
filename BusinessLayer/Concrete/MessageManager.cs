using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrate;
using System;
using System.Collections.Generic;
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

        public List<Message> GetListInbox()
        {
            return _messageDAL.List(x => x.ReceiverMail == "admin@gmail.com");
        }
        public List<Message> GetListSendbox()
        {
            return _messageDAL.List(x => x.SenderMail == "admin@gmail.com");
        }

        public void UpdateMessage(Message Message)
        {
            _messageDAL.Update(Message);
        }
    }
}
