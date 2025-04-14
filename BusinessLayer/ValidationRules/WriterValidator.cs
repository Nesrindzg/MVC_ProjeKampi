using EntityLayer.Concrate;
using FluentValidation; // AbstractValidator Kütüphanesi buradan geliyor
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator : AbstractValidator<Writer> // Üzerinde çalıştığımız entitiy göndericez
    {
        public WriterValidator() // Validator sınıfları içinde kullanacağımız doğrulama kurallarını construcor içine (ctor) yazarız
        {
            RuleFor(x=>x.WriterName).NotEmpty().WithMessage("Yazar Adı Boş Geçilemez!");
            RuleFor(x=>x.WriterSurname).NotEmpty().WithMessage("Yazar Adı Boş Geçilemez!");
            RuleFor(x=>x.WriterTitle).NotEmpty().WithMessage("Yazar Title Boş Geçilemez!");
            RuleFor(x => x.WriterMail).NotEmpty().WithMessage("Mail Boş Geçilemez!");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Hakkımda Boş Geçilemez!");
            RuleFor(x => x.WriterAbout).Must(m=> m!=null && m.ToLower().Contains("a")).WithMessage("Hakkımda a harfi geçmelidir!"); // Hakkımda kısmında a harfi geçmelidir
            RuleFor(x => x.WriterAbout).MaximumLength(100).WithMessage("Lütfen 100 Karakterden Fazla Giriş Yapmayınız.");

        }
    }
}
