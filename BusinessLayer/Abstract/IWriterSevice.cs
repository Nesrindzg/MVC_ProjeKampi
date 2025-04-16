using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrate;

namespace BusinessLayer.Abstract
{
    public interface IWriterSevice
    {
        void AddWriter(Writer writer);  
        void DeleteWriter(Writer writer);
        void UpdateWriter(Writer writer);
        List<Writer> GetList();
        Writer GetByID(int id);
    }
}
