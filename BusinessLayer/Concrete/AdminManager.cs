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
    public class AdminManager : IAdminService
    {
        IAdminDAL _adminDAL;

        public AdminManager(IAdminDAL adminDAL)
        {
            _adminDAL = adminDAL;
        }

        public void AddAdmin(Admin admin)
        {
            _adminDAL.Insert(admin);
        }

        public void DeleteAdmin(Admin admin)
        {
            _adminDAL.Update(admin);
        }

        public List<Admin> GetList()
        {
            return _adminDAL.List();
        }

        public Admin Login(string username, string password)
        {
            return _adminDAL.Get(x => x.AdminUserName == username && x.AdminPassword == password);
        }

        public void UpdateAdmin(Admin admin)
        {
            _adminDAL.Update(admin);
        }
    }
}
