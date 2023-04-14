using DTOLayer.DTOs.AppUserDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.FluentValidation
{
    public class AppUserRegisterValidator : AbstractValidator<AppUserRegisterDTOs>
    {
        public AppUserRegisterValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Zəhmət olmasa bu xananı doldurun!");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Zəhmət olmasa bu xananı doldurun!");
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Zəhmət olmasa bu xananı doldurun!");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Zəhmət olmasa bu xananı doldurun!");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Zəhmət olmasa bu xananı doldurun!");
            RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("Zəhmət olmasa bu xananı doldurun!");
            RuleFor(x => x.UserName).MinimumLength(4).WithMessage("Minimum 4 simvoldan ibarət olmalıdır");
            RuleFor(x => x.UserName).MaximumLength(20).WithMessage("Maksimum 20 simvoldan ibarət olmalıdır");
            RuleFor(x => x.Password).Equal(e => e.ConfirmPassword).WithMessage("Şifrələr bir biri ilə eyni deyil!");
        }
    }
}
