using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using BusinessLayer.ValidationRules;
using FluentValidation.Results;

namespace MVC_ProjeKampi.Controllers
{
    public class WriterPanelController : Controller
    {
        HeadingManager hm= new HeadingManager(new EFHeadingDAL());
        CategoryManager cm = new CategoryManager(new EFCategoryDAL());
        WriterManager wm = new WriterManager(new EFWriterDAL());
        WriterValidator writerValidator = new WriterValidator();

        [HttpGet]
        public ActionResult WriterProfile()
        {
            int id = Convert.ToInt32(Session["WriterID"]);
            var writerValue = wm.GetByID(id);
            return View(writerValue);
        }
        [HttpPost]
        public ActionResult WriterProfile(Writer p)
        {
            ValidationResult result = writerValidator.Validate(p);
            if (result.IsValid)
            {
                wm.UpdateWriter(p);
                return RedirectToAction("AllHeading");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        public ActionResult MyHeading()
        {
            int id = Convert.ToInt32(Session["WriterID"]);
            var values = hm.GetListByWriter(id);
            return View(values);
        }

        public ActionResult AllHeading(int page=1)
        {
            var values = hm.GetList().ToPagedList(page,5);
            return View(values);
        }

        [HttpGet]
        public ActionResult NewHeading()
        {
            List<SelectListItem> categoryValue = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }).ToList();
            ViewBag.Categories = categoryValue;
            return View();
        }

        [HttpPost]
        public ActionResult NewHeading(Heading p)
        {
            p.HeadingTime = DateTime.Parse(DateTime.Now.ToShortDateString());
            int id = Convert.ToInt32(Session["WriterID"]);
            p.WriterID = id;
            p.HeadingStatus = true;
            hm.AddHeading(p);
            return RedirectToAction("MyHeading");
        }

        [HttpGet]
        public ActionResult EditHeading(int id)
        {
            List<SelectListItem> categoryValue = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }).ToList();
            ViewBag.Categories = categoryValue;
            var headingValue = hm.GetById(id);
            return View(headingValue);
        }

        [HttpPost]
        public ActionResult EditHeading(Heading p)
        {
            hm.UpdateHeading(p);
            return RedirectToAction("MyHeading");
        }

        public ActionResult DeleteHeading(int id)
        {
            var headingValue = hm.GetById(id);
            if (headingValue.HeadingStatus == true)
            {
                headingValue.HeadingStatus = false;
            }
            else
            {
                headingValue.HeadingStatus = true;
            }
            hm.DeleteHeading(headingValue);
            return RedirectToAction("MyHeading");
        }
    }
}