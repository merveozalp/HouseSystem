using BuildingSystem.Entities.Dtos;
using FluentValidation;

namespace BuildingSystem.Business.Validations
{
    public class BuildingDtoValidation : AbstractValidator<BuildingDto>
    {
        public BuildingDtoValidation()
        {
            RuleFor(x => x.BuildingName).NotNull().WithMessage("Bina Adını Lütfen Doldurunuz.");
            RuleFor(x => x.BuildingName).MaximumLength(3).MinimumLength(2).WithMessage("Geçerli Uzunlukta Veri Giriniz");
            RuleFor(x => x.TotalFlat).NotNull().WithMessage("Lütfen Boş Bırakmayınız.");
            RuleFor(x => x.TotalFlat).Must(x => x >= 1 && x <= 30).WithMessage("1 ile 30 arasında giriniz.");
        }
    }
}
