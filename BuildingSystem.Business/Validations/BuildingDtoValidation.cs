using BuildingSystem.Entities.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingSystem.Business.Validations
{
    public class BuildingDtoValidation:AbstractValidator<BuildingDto>
    {
        public BuildingDtoValidation()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("Bina Adını Lütfen Doldurunuz.");
            RuleFor(x => x.Name).MaximumLength(1).WithMessage("Geçerli Uzunlukta Veri Giriniz");
            RuleFor(x => x.TotalFlat).NotNull().WithMessage("Lütfen Boş Bırakmayınız.");
           // RuleFor(x => x.TotalFlat).Must(x => x >= 1 && x <= 30).WithMessage("1 ile 30 arasında giriniz.");
        }
    }
}
