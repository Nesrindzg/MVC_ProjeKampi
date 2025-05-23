﻿using EntityLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAdminService
    {
        Admin Login(string username, string password);
        List<Admin> GetList();

        void UpdateAdmin(Admin admin);
        void AddAdmin(Admin admin);
        void DeleteAdmin(Admin admin);
    }
}
