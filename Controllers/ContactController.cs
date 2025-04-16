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
    public class ContactController : Controller
    {
        ContactManager cm = new ContactManager(new EFContactDAL());
        MessageManager mm = new MessageManager(new EFMessageDAL());
        ContactValidator cv = new ContactValidator();
        public ActionResult Index()
        {
            var contactValues = cm.GetList();
            return View(contactValues);
        }
        [HttpGet]
        public ActionResult AddContact()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddContact(Contact contact)
        {
            var result = cv.Validate(contact);
            if (result.IsValid)
            {
                cm.AddContact(contact);
                return RedirectToAction("Index");
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

        public ActionResult GetContactDetails(int id)
        {
            var contactValue = cm.GetById(id);
            return View(contactValue);
        }

        public PartialViewResult _ContactLeftBox()
        {
            var contactCount = cm.GetList().Count();
            ViewBag.contactCount = contactCount;

            var inboxCount = mm.GetListInbox().Count();
            ViewBag.inboxCount = inboxCount;

            var sendboxCount = mm.GetListSendbox().Where(m=>m.IsDraft==false).Count();
            ViewBag.sendboxCount = sendboxCount;

            var draftCount = mm.GetListSendbox().Where(m => m.IsDraft == true).Count();
            ViewBag.draftCount = draftCount;
            return PartialView();
        }
        public PartialViewResult _ContactTopBox()
        {
            return PartialView();
        }
    }
}