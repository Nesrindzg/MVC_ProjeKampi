using EntityLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract // Burasıda veritabanında crud-dml gibi işlemler her tabloda(I..DAL) ortak olduğu için bir ana interface ihtiyacımız var burası orası.
{
    public interface IRepository <T> // Bu genel interfacedeki işlemler hangi tablo için gerekli ise T'ye onun bilgisi *Entity katmanından* gelecek örn:Category
    {
        List<T> List(); //List veya Listele farketmez.
        void Insert(T p);
        void Update(T p);

        T Get(Expression<Func<T, bool>> filter); // T Generic bir tiptir herhangi bir sınıfı(entity) temsil eder. Parantez içide LİNQ filtreleme ifadesidir
        void Delete(T p);

        List<T> List(Expression<Func<T, bool>> filter);
    }
}
