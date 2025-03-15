using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrate
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }

        [StringLength(100)] 
        public string CategoryName { get; set; }

        [StringLength(500)] 
        public string CategoryDescription { get; set; }
        public bool CategoryStatus { get; set; } // Durumu aktif pasif olarak yöneticez. Veri Silme İşlemi Yerine pasif olarak yapıcaz. Çünkü buna bağlı içeriklerde silinecek.
        public ICollection<Heading> Headings { get; set; } // Başlık tablosuna referans olacak

    }
}
