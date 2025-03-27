using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repostories;
using EntityLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDAL _categoryDAL; //Veritabanımı temsil eden interfaceler DAL katmanında yer alıyor.

        public CategoryManager(ICategoryDAL categoryDAL)
        {
            _categoryDAL = categoryDAL;
        }

        public void CategoryAdd(Category category)
        {
            _categoryDAL.Insert(category);
        }

        public void CategoryDelete(Category category)
        {
            _categoryDAL.Delete(category);
        }

        public void CategoryUpdate(Category category)
        {
            _categoryDAL.Update(category); 
        }

        public Category GetByID(int id)
        {
            return _categoryDAL.Get(x=> x.CategoryID==id);
        }

        public List<Category> GetList()
        {
            return _categoryDAL.List();
        }

        // Kullanmıyoruz. Bunun yerine fluent validation(Business da ValidationRules)
        //GenericRepository<Category> repo= new GenericRepository<Category>(); // Data Access katmanına erişim

        //public List<Category> GetAllBL()
        //{
        //    return repo.List();
        //}

        //public void CategoryAddBL(Category p)
        //{
        //    /*if (p.CategoryName=="" || p.CategoryName.Length<=3)
        //    {
        //        // Hata mesajı yazdır.
        //    }
        //    else
        //    {
        //        // Koşullar tamamsa ekleme işlemini burda yaptırıyoruz.
        //        repo.Insert(p);
        //    }*/

        //    repo.Insert(p);
        //}

    }
}
