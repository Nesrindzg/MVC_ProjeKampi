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
    public class AboutManager : IAboutService
    {
        IAboutDAL _aboutDAL;

        public AboutManager(IAboutDAL aboutDAL)
        {
            _aboutDAL = aboutDAL;
        }

        public void AddAbout(About About)
        {
            _aboutDAL.Insert(About);
        }

        public void DeleteAbout(About About)
        {
            _aboutDAL.Delete(About);
        }

        public About GetById(int id)
        {
            return _aboutDAL.Get(x => x.AboutID == id);
        }

        public List<About> GetList()
        {
            return _aboutDAL.List();
        }

        public void UpdateAbout(About About)
        {
            _aboutDAL.Update(About);
        }
    }
}
