using EntityLayer.Concrate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı İsmi Boş Geçilemez!");
            RuleFor(x => x.UserMail).NotEmpty().WithMessage("Mail Boş Geçilemez!");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu Boş Geçilemez!");
            RuleFor(x => x.Message).NotEmpty().WithMessage("Mesaj Boş Geçilemez!");
            RuleFor(x => x.Subject).MaximumLength(50).WithMessage("Lütfen 50 Karakterden Fazla Giriş Yapmayınız.");
            RuleFor(x => x.UserName).MinimumLength(3).WithMessage("Lütfen En Az 3 Karakter Girişi Yapınız.");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("Lütfen En Az 3 Karakter Girişi Yapınız.");
        }
    }
}
