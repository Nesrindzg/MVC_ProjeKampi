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
    }
}