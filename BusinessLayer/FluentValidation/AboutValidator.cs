using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.FluentValidation
{
    public class AboutValidator : AbstractValidator<About>
    {
        public AboutValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlıq hissə boş saxlanıla bilməz");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Təsvir hissə boş saxlanıla bilməz");
            RuleFor(x => x.Title).MinimumLength(5).WithMessage("Başlıq hissəsi minimum 5 simvoldan ibarət olmalıdır");
        }
    }
}
