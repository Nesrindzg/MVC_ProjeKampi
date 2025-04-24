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
    public class ContentManager : IContentService
    {
        IContentDAL _contentDAL;

        public ContentManager(IContentDAL contentDAL)
        {
            _contentDAL = contentDAL;
        }

        public void AddContent(Content content)
        {
            _contentDAL.Insert(content);
        }

        public void DeleteContent(Content content)
        {
           _contentDAL.Delete(content);
        }

        public Content GetById(int id)
        {
            return _contentDAL.Get(x => x.ContentID == id);
        }

        public List<Content> GetList(string p)
        {
           return _contentDAL.List(x=>x.ContentValue.Contains(p));
        }

        public List<Content> GetListByHeadingId(int id)
        {
            return _contentDAL.List(x => x.HeadingID == id);
        }

        public List<Content> GetListByWriter(int id)
        {
            return _contentDAL.List(x => x.WriterID == id);
        }

        public void UpdateContent(Content content)
        {
            _contentDAL.Update(content);
        }
    }
}
