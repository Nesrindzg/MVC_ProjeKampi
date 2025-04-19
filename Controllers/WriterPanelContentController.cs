using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
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
    }
}