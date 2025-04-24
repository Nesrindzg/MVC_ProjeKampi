using EntityLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IContactService
    {
        // CRUD operations
        void AddContact(Contact Contact);
        void UpdateContact(Contact Contact);
        void DeleteContact(Contact Contact);

        // Read operations
        Contact GetById(int id);
        List<Contact> GetList(string p);
    }
}
