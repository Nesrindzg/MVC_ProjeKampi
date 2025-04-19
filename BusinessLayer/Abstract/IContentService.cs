using EntityLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IContentService
    {
        // CRUD operations
        void AddContent(Content content);
        void UpdateContent(Content content);
        void DeleteContent(Content content);

        // Read operations
        Content GetById(int id);
        List<Content> GetList();
        List<Content> GetListByWriter(int id);
        List<Content> GetListByHeadingId(int id);
    }
}
