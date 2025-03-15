using EntityLayer.Concrate;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Heading // Public olmalı ki diğer yerlerden erişim sağlayabilelim.
    {
        [Key] public int HeadingID { get; set; } // prop yazıp tab bas otomatik gelir.
        [StringLength(100)] public string HeadingName { get; set; }
        public DateTime HeadingTime { get; set; }
        public int CategoryID { get; set; } // Ana tablodaki primary key ile aynı isimde olmak zorunda. Yoksa Hata Verir!
        public virtual Category Category { get; set; }
        public ICollection<Content> Contents { get; set; } // Başlık tablosuna referans olacak

        public int WriterID { get; set; } // Başlığı kim hangi yazar oluşturdu referans alacak.
        public virtual Writer Writer { get; set; }
    }
}
