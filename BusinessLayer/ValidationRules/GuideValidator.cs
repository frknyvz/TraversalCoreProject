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
            RuleFor(x=>x.Description).NotEmpty().WithMessage("Açıklama Alanı Boş Geçilemez!");
            RuleFor(x=>x.Image).NotEmpty().WithMessage("Fotoğraf Alanı Boş Geçilemez!");
            RuleFor(x=>x.Name).MaximumLength(30).WithMessage("Lütfen 30 Karakterden Daha Kısa Bir İsim Giriniz!");
            RuleFor(x => x.Name).MinimumLength(2).WithMessage("Lütfen 2 Karakterden Daha Uzun Bir İsim Giriniz!");
        }
    }
}
