using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class ColorValidator : AbstractValidator<Color>
    {
        public ColorValidator()
        {
            //RuleFor(c => c.Id).GreaterThan(0).WithMessage("Id alanı boş geçilemez.");
            RuleFor(c => c.ColorName).NotEmpty().WithMessage("Renk alanı boş geçilemez.");
        }
    }
}
