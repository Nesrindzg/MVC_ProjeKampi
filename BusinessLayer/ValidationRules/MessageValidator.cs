using EntityLayer.Concrate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class MessageValidator : AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(x => x.MessageContent).NotEmpty().WithMessage("Mesaj içeriği boş geçilemez");
            RuleFor(x => x.ReceiverMail).NotEmpty().WithMessage("Alıcı mail adresi boş geçilemez");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu boş geçilemez");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("Konu en az 3 karakter olmalıdır");
            RuleFor(x => x.Subject).MaximumLength(100).WithMessage("Konu en fazla 100 karakter olmalıdır");
            RuleFor(x => x.ReceiverMail).EmailAddress().WithMessage("Geçerli bir e-posta adresi giriniz");
        }

    }
}
