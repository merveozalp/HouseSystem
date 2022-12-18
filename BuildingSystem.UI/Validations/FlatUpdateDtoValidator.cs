using BuildingSystem.Entities.Dtos;
using FluentValidation;

namespace BuildingManager.Web.ValidationRules.FluentValidation
{
    public class FlatUpdateDtoValidator : AbstractValidator<FlatUpdateDto>
    {
        public FlatUpdateDtoValidator()
        {
            RuleFor(x => x.FlatNumber).NotEmpty().WithMessage("Daire Numaras�n� Bo� Ge�meyiniz.");
            RuleFor(x => x.FlatType).NotEmpty().WithMessage("Daire Tipini Giriniz.");
            RuleFor(x => x.FlatType).MaximumLength(4).WithMessage("En fazla 4 karakter girebilrsiniz.");
            RuleFor(x => x.BuildingId).NotEmpty().WithErrorCode("L�tfen Daire Bilgisi Giriniz.");
            RuleFor(x => x.UserId).NotEmpty().WithMessage("L�tfen Kullan�c� Se�iniz.");
        }

    }
}