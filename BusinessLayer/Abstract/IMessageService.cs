using EntityLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IMessageService
    {
        // CRUD operations
        void AddMessage(Message Message);
        void UpdateMessage(Message Message);
        void DeleteMessage(Message Message);

        // Read operations
        Message GetById(int id);
        List<Message> GetListInbox();
        List<Message> GetListSendbox();
    }
}
