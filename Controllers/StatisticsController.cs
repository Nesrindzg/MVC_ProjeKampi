using DataAccessLayer.Concrete;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_ProjeKampi.Controllers
{
    public class StatisticsController : Controller
    {
        // GET: Statistics
        Context c = new Context();
        public ActionResult Index()
        {
            var countCategory = c.Categories.Count();
            var headingYazilim = c.Headings.Count(x => x.Category.CategoryName == "yazılım");
            var writerName = c.Writers.Count(x => x.WriterName.Contains("a"));

            // Aşağıdaki kod sadece bir değer döndürür. Ama bizim aynı anda birden fazla maximum değerimiz olabilir.
            // Yani Spor kategorisine ait 5 başlık varsa, Eğitime ait de 5 başlık olabilir.
            // Bu durumda iki tane max kategori değerimiz olur o yüzden alttaki kod tamamen doğru sayılmaz.
            //var maxCategory = c.Headings
            //        .GroupBy(x => x.Category.CategoryName)
            //        .OrderByDescending(g => g.Count())
            //        .Select(g => g.Key).FirstOrDefault();

            // Önce kategorilere göre maximum olan kayıt sayısını buluyoruz. 
            var maxCount = c.Headings
                .GroupBy(x => x.Category.CategoryName)
                .Max(g => g.Count());

            // Sonra bu maximum başlık sayısına sahip tüm kategorileri alıyoruz
            var maxCategories = c.Headings
                .GroupBy(x => x.Category.CategoryName)
                .Where(g => g.Count() == maxCount) // Her kategoriye ait olan başlık sayısını yukardaki max sayımız ile karşılaştırıyoruz. Eşit olanları alıyoruz.
                .Select(g => g.Key) // Sadece Kategori adlarını alıyoruz
                .ToList(); // Sonuçları listeye çeviriyoruz

            var statusCategoryTrue = c.Categories.Count(x => x.CategoryStatus == true);
            var statusCategoryFalse = c.Categories.Count(x => x.CategoryStatus == false);

            ViewBag.CountCategory = countCategory;
            ViewBag.headingYazilim = headingYazilim;
            ViewBag.writerName = writerName;
            ViewBag.maxCategory = maxCategories;
            ViewBag.statusCategory = statusCategoryTrue-statusCategoryFalse;

            return View();
        }
    }
}