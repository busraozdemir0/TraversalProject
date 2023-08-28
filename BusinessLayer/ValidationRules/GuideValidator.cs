using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.AspNetCore;
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
            RuleFor(x => x.Name).NotEmpty().WithMessage("Lütfen rehber adını giriniz.");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Lütfen rehber açıklamasını giriniz.");
            RuleFor(x => x.Image).NotEmpty().WithMessage("Lütfen rehber görselini giriniz.");
            RuleFor(x => x.Name).MaximumLength(70).WithMessage("Lütfen 70 karakterden daha kısa bir isim giriniz.");
            RuleFor(x => x.Name).MinimumLength(3).WithMessage("Lütfen 3 karakterden daha uzun bir isim giriniz.");
        }
    }
}
