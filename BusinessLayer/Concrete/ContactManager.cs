using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ContactManager: IContactService
    {
        IContactDAL _contactDal;
        public ContactManager(IContactDAL contactDal)
        {
            _contactDal = contactDal;
        }
        public void AddContact(Contact contact)
        {
            _contactDal.Insert(contact);
        }
        public void DeleteContact(Contact contact)
        {
            _contactDal.Delete(contact);
        }
        public Contact GetById(int id)
        {
            return _contactDal.Get(x => x.ContactID == id);
        }
        public List<Contact> GetList()
        {
            return _contactDal.List();
        }
        public void UpdateContact(Contact contact)
        {
            _contactDal.Update(contact);
        }
    }
}
