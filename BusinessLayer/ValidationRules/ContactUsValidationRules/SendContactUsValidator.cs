using DTOLayer.DTOs.ContactDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.ContactUsValidationRules
{
    public class SendContactUsValidator : AbstractValidator<SendMessageDTO>
    {
        public SendContactUsValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ad Alanı Boş Geçilemez!");

            RuleFor(x => x.Mail).NotEmpty().WithMessage("Mail Alanı Boş Geçilemez!");

            RuleFor(x => x.Subject).NotEmpty().WithMessage("Başlık Alanı Boş Geçilemez!");

            RuleFor(x => x.MessageBody).NotEmpty().WithMessage("Mesaj İçeriği Boş Geçilemez!");

            RuleFor(x => x.Name).MaximumLength(30).WithMessage("En Fazla 30 Karakter Girebilirsiniz!");

            RuleFor(x => x.Mail).MaximumLength(30).WithMessage("En Fazla 30 Karakter Girebilirsiniz!");

            RuleFor(x => x.Subject).MaximumLength(70).WithMessage("En Fazla 70 Karakter Girebilirsiniz!");

            RuleFor(x => x.MessageBody).MaximumLength(500).WithMessage("En Fazla 500 Karakter Girebilirsiniz!");
        }
    }
}
