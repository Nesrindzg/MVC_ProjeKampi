﻿using EntityLayer.Concrate;
using FluentValidation; // AbstractValidator Kütüphanesi buradan geliyor
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CategoryValidator:AbstractValidator<Category> // Üzerinde çalıştığımız entitiy göndericez
    {
        public CategoryValidator() // Validator sınıfları içinde kullanacağımız doğrulama kurallarını construcor içine (ctor) yazarız
        {
            RuleFor(x=>x.CategoryName).NotEmpty().WithMessage("Kategori Adı Boş Geçilemez");
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Açıklama Boş Geçilemez");
            RuleFor(x => x.CategoryName).MinimumLength(3).WithMessage("Lütfen En Az 3 Karakter Giriniz");
            RuleFor(x => x.CategoryName).MaximumLength(20).WithMessage("Lütfen 20 Karakterden Fazla Giriş Yapmayınız");

        }
    }
}
