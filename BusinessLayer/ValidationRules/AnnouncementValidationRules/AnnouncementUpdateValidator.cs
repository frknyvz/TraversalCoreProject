using DTOLayer.DTOs.AnnouncementDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.AnnouncementValidationRules
{
    public class AnnouncementUpdateValidator : AbstractValidator<AnnouncementUpdateDTO>
    {
        public AnnouncementUpdateValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık Alanı Boş Geçilemez!");

            RuleFor(x => x.Content).NotEmpty().WithMessage("Başlık Alanı Boş Geçilemez!");

            RuleFor(x => x.Title).MinimumLength(3).WithMessage("En Az 3 Karakter Giriniz!");

            RuleFor(x => x.Content).MinimumLength(5).WithMessage("En Az 5 Karakter Giriniz!");

            RuleFor(x => x.Title).MaximumLength(50).WithMessage("En Fazla 50 Karakter Girebilirsiniz!");

            RuleFor(x => x.Content).MaximumLength(300).WithMessage("En Fazla 300 Karakter Girebilirsiniz!");
        }
    }
}
