﻿using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repostories;
using EntityLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EFAdminDAL:GenericRepository<Admin>, IAdminDAL
    {
    }
}
