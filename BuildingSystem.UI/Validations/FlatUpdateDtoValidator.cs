using BuildingSystem.Entities.Dtos;
using FluentValidation;

namespace BuildingManager.Web.ValidationRules.FluentValidation
{
    public class FlatUpdateDtoValidator : AbstractValidator<FlatUpdateDto>
    {
        public FlatUpdateDtoValidator()
        {
            RuleFor(x => x.FlatNumber).NotEmpty().WithMessage("Daire Numarasýný Boþ Geçmeyiniz.");
            RuleFor(x => x.FlatType).NotEmpty().WithMessage("Daire Tipini Giriniz.");
            RuleFor(x => x.FlatType).MaximumLength(4).WithMessage("En fazla 4 karakter girebilrsiniz.");
            RuleFor(x => x.BuildingId).NotEmpty().WithErrorCode("Lütfen Daire Bilgisi Giriniz.");
            RuleFor(x => x.UserId).NotEmpty().WithMessage("Lütfen Kullanýcý Seçiniz.");
        }

    }
}