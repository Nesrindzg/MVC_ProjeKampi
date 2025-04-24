using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrate;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_ProjeKampi.Controllers
{
    public class WriterPanelMessageController : Controller
    {
        MessageManager mm = new MessageManager(new EFMessageDAL());
        MessageValidator mv = new MessageValidator();
        string p = "";
        public ActionResult Inbox()
        {
            var mail = Session["WriterMail"].ToString();
            var messageList = mm.GetListInbox(mail, p);
            return View(messageList);
        }
        public ActionResult Sendbox()
        {
            var mail = Session["WriterMail"].ToString();
            var messageList = mm.GetListSendbox(mail, p);
            return View(messageList);
        }

        public ActionResult GetMessageDetails(int id)
        {
            var message = mm.GetById(id);
            return View(message);
        }
        public ActionResult GetMessageRead(int id)
        {
            var mail = Session["WriterMail"].ToString();
            var message = mm.GetById(id);
            if (message.SenderMail!=mail)
            {
                message.IsRead = true;
            }
            mm.UpdateMessage(message);
            return View(message);
        }

        public PartialViewResult _MessageListMenu()
        {
            var mail = Session["WriterMail"].ToString();
            var inboxCount = mm.GetListInbox(mail, p).Where(m => m.IsRead == false).Count();
            ViewBag.inboxCount = inboxCount;

            var sendboxCount = mm.GetListSendbox(mail, p).Where(m => m.IsDraft == false).Count();
            ViewBag.sendboxCount = sendboxCount;

            var draftCount = mm.GetListSendbox(mail, p).Where(m => m.IsDraft == true).Count();
            ViewBag.draftCount = draftCount;
            return PartialView();
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
                p.SenderMail = Session["WriterMail"].ToString(); //Session'dan al
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
            var mail = Session["WriterMail"].ToString();
            var values = mm.GetListSendbox(mail, p).Where(x => x.IsDraft == true).ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult EditMessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EditMessage(Message p, string submitType)
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

            p.SenderMail = Session["WriterMail"].ToString(); //Session'dan al
            mm.UpdateMessage(p);

            return RedirectToAction("Inbox");

        }
    }
}