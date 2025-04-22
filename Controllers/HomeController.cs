using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_ProjeKampi.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [AllowAnonymous]
        public ActionResult HomePage()
        {
            HeadingManager hm= new HeadingManager(new EFHeadingDAL());
            var headingCount = hm.GetList().Count;
            ViewBag.HeadingCount = headingCount;

            ContentManager cm = new ContentManager(new EFContentDAL());
            var contentCount = cm.GetList().Count;
            ViewBag.ContentCount = contentCount;

            CategoryManager catm = new CategoryManager(new EFCategoryDAL());
            var categoryCount = catm.GetList().Count;
            ViewBag.CategoryCount = categoryCount;

            WriterManager wm = new WriterManager(new EFWriterDAL());
            var writerCount = wm.GetList().Count;
            ViewBag.WriterCount = writerCount;
            return View();
        }

        [HttpPost]
        public ActionResult AddContact(string UserName, string UserMail, string Subject, string Message)
        {
            // Burada gelen parametrelerle işlem yapabilirsin
            var contact = new Contact
            {
                UserName = UserName,
                UserMail = UserMail,
                Subject = Subject,
                Message = Message,
                MessageDate = DateTime.Now
            };

            ContactManager cm = new ContactManager(new EFContactDAL());
            cm.AddContact(contact);
            ViewBag.Message = "Mesajınız başarıyla gönderilmiştir.";
            return RedirectToAction("HomePage");
        }

    }
}