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
    public class MessageController : Controller
    {
        MessageManager mm = new MessageManager(new EFMessageDAL());
        MessageValidator mv = new MessageValidator();
        public ActionResult Inbox()
        {
            var messageList = mm.GetListInbox();
            return View(messageList);
        }
        public ActionResult Sendbox()
        {
            var messageList = mm.GetListSendbox();
            return View(messageList);
        }

        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewMessage(Message p, string submitType)
        {
            if (submitType == "draft")
            {
                ViewBag.Message = "Mesaj Taslak Olarak Kaydedildi.";
                p.IsDraft = true; 
                p.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            }
            else
            {
                ViewBag.Message = "Mesaj Gönderildi.";
                p.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                p.IsDraft = false; 
            }

            var result = mv.Validate(p);
            if (result.IsValid)
            {
                p.SenderMail = "admin@gmail.com";
                mm.AddMessage(p);
                return RedirectToAction("Inbox");
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

      
        public ActionResult DraftMessage()
        {
            var values = mm.GetListSendbox().Where(x => x.IsDraft == true).ToList();
            return View(values);
        }

        public ActionResult GetMessageDetails(int id)
        {
            var message = mm.GetById(id);
            return View(message);
        }
        public ActionResult GetMessageRead(int id)
        {
            var message = mm.GetById(id);
            return View(message);
        }
    }
}