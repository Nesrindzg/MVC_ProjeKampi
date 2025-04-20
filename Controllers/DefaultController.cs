using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_ProjeKampi.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        HeadingManager hm=new HeadingManager(new EFHeadingDAL());
        ContentManager cm= new ContentManager(new EFContentDAL());
        public ActionResult Headings()
        {
            var headingValues = hm.GetList();
            return View(headingValues);
        }
        public PartialViewResult Index(int id=0)
        {
            var contentValues = cm.GetListByHeadingId(id);
            return PartialView(contentValues);
        }
    }
}