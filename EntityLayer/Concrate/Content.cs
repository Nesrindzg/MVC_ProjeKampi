using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrate
{
   public class Content
    {
        [Key] public int ContentID { get; set; }
        [StringLength(100)] public string ContentValue { get; set; }
        public DateTime ContentDate { get; set; }

        // Diğer Tablolarla (Entity Sınıfları İle) İlişkili Olan Kolonlar (Foregin Key)
        // ContentYazar 
        // ContentBaslik

        public bool ContentStatus { get; set; } // İçerik aktif mi değil mi?
        public int HeadingID { get; set; }
        public virtual Heading Heading { get; set; } // Her içeriğin bir başlığı var
        public int? WriterID { get; set; } // ? nullable yani boş bırakılabilir demek oluyor.
        public virtual Writer Writer { get; set; } // Her içeriğin bir yazarı var.
    }
}
