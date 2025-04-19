using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.Helpers;

namespace MVC_ProjeKampi.Controllers
{
    public class LoginController : Controller
    {
        AdminManager adminManager = new AdminManager(new EFAdminDAL());
        WriterManager writerManager = new WriterManager(new EFWriterDAL());

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Admin p)
        {
            var hashedPassword = Crypto.Hash(p.AdminPassword,"MD5");
            var adminUserInfo = adminManager.GetList().FirstOrDefault(x => x.AdminUserName == p.AdminUserName && x.AdminPassword == hashedPassword);
            if (adminUserInfo != null)
            {
                //Varolan veritabanındaki password değerini hash haliyle değiştirmek için:
                //adminUserInfo.AdminPassword = hashedPassword;
                //adminManager.UpdateAdmin(adminUserInfo);
                FormsAuthentication.SetAuthCookie(adminUserInfo.AdminUserName, false);
                Session["AdminUserName"] = adminUserInfo.AdminUserName;
                return RedirectToAction("MySkills", "AdminCategory");
            }
            else
            {
                ViewBag.Message = "Kullanıcı adı veya şifre hatalı!";
            }

            return View();
        }
        [HttpGet]
        public ActionResult WriterLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult WriterLogin(Writer p)
        {
            var hashedPassword = Crypto.Hash(p.WriterPassword, "MD5");
            var writerUserInfo = writerManager.GetList().FirstOrDefault(x => x.WriterMail == p.WriterMail && x.WriterPassword == hashedPassword);
            if (writerUserInfo != null)
            {
                FormsAuthentication.SetAuthCookie(writerUserInfo.WriterMail, false);
                Session["WriterMail"] = writerUserInfo.WriterMail;
                Session["WriterID"] = writerUserInfo.WriterID;
                Session["WriterFullName"] = writerUserInfo.WriterName+" "+writerUserInfo.WriterSurname;
                return RedirectToAction("MyContent", "WriterPanelContent");
            }
            else
            {
                ViewBag.Message = "Kullanıcı adı veya şifre hatalı!";
            }
            return View();
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("WriterLogin", "Login");
        }
    }
}