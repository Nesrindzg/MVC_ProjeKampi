using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrate;
using FluentValidation.Results; // Valudation sonuçları için şart

namespace MVC_ProjeKampi.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        CategoryManager cm = new CategoryManager(new EFCategoryDAL()); // Business katmanına erişmek için

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetCategoryList()
        {
            var categoryValues = cm.GetList(); // Business katmanındaki bir action-metoda istek atar
            return View(categoryValues); // sonucu view olarak kullanıcıya döndürür (ui)
        }

        [HttpGet] // Sayfa yüklendiği zaman AddCategory sayfası için burdaki kodlar çalışacak.
        public ActionResult AddCategory()
        {
            return View(); // Bu metoda yönlendir.
        }

        [HttpPost] // Sayfada bir şey post edildiği zaman gönderildiği zaman çalışacak altındaki metod
        public ActionResult AddCategory(Category p) // Sayfada bişi gönderildiği zaman burdaki kodlar çalışacak.
        {
            //cm.CategoryAddBL(p);
            CategoryValidator categoryValidator = new CategoryValidator(); // Kuralları koşulları çağırmak için

            // using FluentValidation.Results; kullanman gerek datacomponent değil!!!!
            ValidationResult validationResult = categoryValidator.Validate(p); // Validate => (gelen değer geçerli mi? kontrol et) anlamına geliyor

            if(validationResult.IsValid) // Eğerki sonuç validasyona uygunsa geçerli ise
            {
                cm.CategoryAdd(p);
                return RedirectToAction("GetCategoryList"); // Bu metoda yönlendir.
            }
            else
            {
                foreach (var item in validationResult.Errors) // Hata mesajlarının olduğu dizi ile döngü oluştur
                {
                    ModelState.AddModelError(item.PropertyName,item.ErrorMessage);
                }
            }
                return View(); // Bu metoda yönlendir.
        }
    }
}