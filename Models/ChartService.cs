using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_ProjeKampi.Models
{
    public class ChartService
    {
        private readonly HeadingManager _headingManager;
        private readonly ContentManager _contentManager;

        public ChartService()
        {
            _headingManager = new HeadingManager(new EFHeadingDAL());
            _contentManager = new ContentManager(new EFContentDAL());
        }

        public List<CategoryChart> GetContentList()
        {
            return _contentManager.GetList("")
                .Where(w => w.ContentStatus)
                .GroupBy(x => x.Heading.Category.CategoryName)
                .Select(x => new CategoryChart
                {
                    CategoryName = x.Key,
                    CategoryCount = x.Count()
                }).ToList();
        }

        public List<CategoryChart> GetBlogList()
        {
            return _headingManager.GetList()
                .Where(w => w.HeadingStatus)
                .GroupBy(x => x.Category.CategoryName)
                .Select(x => new CategoryChart
                {
                    CategoryName = x.Key,
                    CategoryCount = x.Count()
                }).ToList();
        }

        public List<CategoryChart> GetWriterList()
        {
            return _contentManager.GetList("")
                .Where(w => w.ContentStatus)
                .GroupBy(x => x.Heading.Category.CategoryName)
                .Select(x => new CategoryChart
                {
                    CategoryName = x.Key,
                    CategoryCount = x.Count()
                }).ToList();
        }
    }

}