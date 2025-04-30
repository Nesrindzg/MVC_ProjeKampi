using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using MVC_ProjeKampi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_ProjeKampi.Controllers
{
    public class ChartController : Controller
    {
        private readonly ChartService _chartService = new ChartService();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult BlogChart()
        {
            var data = _chartService.GetBlogList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ColumnChart()
        {
            return View();
        }

        public ActionResult ContentListChart()
        {
            var data = _chartService.GetContentList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }


        public ActionResult LineChart()
        {
            return View();
        }

        public ActionResult WriterListChart()
        {
            var data = _chartService.GetWriterList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }

}