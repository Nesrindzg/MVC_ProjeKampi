using DataAccessLayer.Abstract;
using EntityLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repostories 
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        Context c = new Context(); // Veritabanı bağlantı yolu
        DbSet<T> _object; // Hangi tabloyla (entity ile) çalışacaksa o atanır
        public GenericRepository()
        {
            _object=c.Set<T>(); // Dışarıdan gelen entity neyse onu atadık.
        }
        public void Delete(T p)
        {
            _object.Remove(p);
            c.SaveChanges();
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            return _object.SingleOrDefault(filter); // SingleOrDefault metodu sadece tek bir değer döndürür
            // ✅ 1. Find() – Sadece DbSet<T> ile Çalışır
            //✔ Birincil anahtar(Primary Key) ile arama yapar.
            //✔ Yalnızca DbSet<T> nesnesinde kullanılabilir.
            //✔ Bellekte filtreleme yapmaz, doğrudan veritabanına SQL sorgusu atar.
            // ✅ 2.SingleOrDefault() – Herhangi Bir Koşul İçin Kullanılır
            //✔ Herhangi bir koşul ile nesne arayabilirsin(Sadece Primary Key değil).
            //✔ LINQ sorgularında çalışır.
            //✔ Eğer birden fazla sonuç dönerse hata verir.
            //  Özellik                     Find()                                  SingleOrDefault()
            //Filtreleme Alanı    Sadece Primary Key ile arama yapar        Herhangi bir koşul ile arama yapar
            //Bellek Kullanımı    Önce bellekte arar, yoksa DB'ye gider	    Her zaman veritabanına sorgu atar
            //Sonuç Sayısı        Birden fazla sonuç dönebilir              Birden fazla kayıt varsa hata fırlatır
            //Performans          Daha hızlıdır(Çünkü önbelleğe bakar)      Daha yavaştır(Her zaman DB'ye gider)
        }

        public void Insert(T p)
        {
            _object.Add(p);
            c.SaveChanges();
        }

        public List<T> List()
        {
            return _object.ToList();
        }

        public List<T> List(Expression<Func<T, bool>> filter)
        {
            return _object.Where(filter).ToList(); // gelen koşul neyse ona göre listeleme yapar.
        }

        public void Update(T p)
        {
            c.SaveChanges();
        }
    }
}
