using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class GuideValidator : AbstractValidator<Guide>
    {
        public GuideValidator()
        {
            RuleFor(x=>x.Name).NotEmpty().WithMessage("Ad Alanı Boş Geçilemez!");
            RuleFor(x=>x.Route).NotEmpty().WithMessage("Rota Alanı Boş Geçilemez!");
            RuleFor(x=>x.Image).NotEmpty().WithMessage("Fotoğraf Alanı Boş Geçilemez!");
            RuleFor(x=>x.Age).NotEmpty().WithMessage("Yaş Alanı Boş Geçilemez!");
            RuleFor(x=>x.Age).GreaterThan(0).WithMessage("Yaş Alanı 0'dan küçük olamaz");

            RuleFor(x=>x.Name).MaximumLength(30).WithMessage("Lütfen 30 Karakterden Daha Kısa Bir İsim Giriniz!");
            RuleFor(x => x.Name).MinimumLength(2).WithMessage("Lütfen 2 Karakterden Daha Uzun Bir İsim Giriniz!");
        }
    }
}
