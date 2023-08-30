using DTOLayer.DTOs.AnnouncementDTOs;
using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AnnouncementValidator : AbstractValidator<AnnouncementAddDto>
    {
        public AnnouncementValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Lütfen başlığı boş geçmeyiniz.");
            RuleFor(x => x.Content).NotEmpty().WithMessage("Lütfen duyuru içeriğini boş geçmeyiniz.");
            RuleFor(x => x.Title).MinimumLength(5).WithMessage("Lütfen en az 5 karakter veri girişi yapınız.");
            RuleFor(x => x.Content).MinimumLength(10).WithMessage("Lütfen en az 10 karakter veri girişi yapınız.");
            RuleFor(x => x.Title).MaximumLength(100).WithMessage("Lütfen en fazla 100 karakter veri girişi yapınız.");
            RuleFor(x => x.Content).MaximumLength(1000).WithMessage("Lütfen en fazla 1000 karakter veri girişi yapınız.");
        }
    }
}
