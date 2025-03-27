using EntityLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetList();
        void CategoryAdd(Category category);

        Category GetByID(int id);

        void CategoryDelete(Category category); // Bu parametre ile Category sınıfındaki tüm alanlara ulaşabileceğiz.

        void CategoryUpdate(Category category);
    }
}
