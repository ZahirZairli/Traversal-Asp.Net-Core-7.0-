using DTOLayer.DTOs.AnnouncementDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.FluentValidation
{
    public class AnnouncementValidator : AbstractValidator<AddAnnouncementDto>
    {
        public AnnouncementValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Zəhmət olmasa bu hissəni boş saxlamayın!");
            RuleFor(x => x.Title).MinimumLength(5).WithMessage("Zəhmət olmasa ən az 5 simvol daxil edin!");
            RuleFor(x => x.Content).MinimumLength(50).WithMessage("Zəhmət olmasa ən az 20 simvol daxil edin!");
            RuleFor(x => x.Title).MaximumLength(20).WithMessage("Zəhmət olmasa ən çox 20 simvol daxil edin!");
            RuleFor(x => x.Content).MaximumLength(500).WithMessage("Zəhmət olmasa ən çox 500 simvol daxil edin!");
            RuleFor(x => x.Content).NotEmpty().WithMessage("Zəhmət olmasa bu hissəni boş saxlamayın!");
        }
    }
}
