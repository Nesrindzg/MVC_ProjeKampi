using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_ProjeKampi.Controllers
{
    public class WriterPanelContentController : Controller
    {
        ContentManager cm = new ContentManager(new EFContentDAL());
        public ActionResult MyContent()
        {
            int id = Convert.ToInt32(Session["WriterID"]);
            var values = cm.GetListByWriter(id);
            return View(values);
        }

        [HttpGet]
        public ActionResult AddContent(int id)
        {
            ViewBag.HeadingName = id;
            return View();
        }

        [HttpPost]
        public ActionResult AddContent(Content p)
        {
            int id = Convert.ToInt32(Session["WriterID"]);
            p.ContentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.ContentStatus = true;
            p.WriterID = id;
            cm.AddContent(p);
            return RedirectToAction("MyContent");
        }

        public ActionResult ToDoList()
        {
            return View();
        }
    }
}