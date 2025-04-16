using EntityLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAboutService
    {
        // CRUD operations
        void AddAbout(About About);
        void UpdateAbout(About About);
        void DeleteAbout(About About);

        // Read operations
        About GetById(int id);
        List<About> GetList();
    }
}
