using EntityLayer;
using EntityLayer.Concrate; // Entity katmanındaki classlara erişmek için çünkü tablolar orada.
using System;
using System.Collections.Generic;
using System.Data.Entity; // DbContext'i Kalıtım Aldı
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context:DbContext
    {
        public DbSet<About> Abouts { get; set; } // Abouts burada SQL'deki tablo ismini temsil eder. Abaout ise buradaki class ismini.
        public DbSet<Category> Categories { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Content> Contents { get; set; }
        public DbSet<Heading> Headings { get; set; }
        public DbSet<Writer> Writers { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<ImageFile> ImageFiles { get; set; }
        public DbSet<Admin> Admins { get; set; }
    }
}
