using EntityLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract // Burdaki I...DAL interfaceleri benim veritabanındaki tabloları temsil ediyor.
{
    // Bu mantık yanlıştır. Çünkü her sınıf için bir interface ve ona bağlı classlar oluşturup işlemler yapmak kod tekrarını oluşturur.
    // CRUD İşlemleri
    /*
    List<Category> List(); //List veya Listele farketmez.
    void Insert(Category p);
    void Update(Category p);
    void Delete(Category p);
    */
    public interface ICategoryDAL :IRepository<Category>
    {
        
    }
}
