using BuildingSystem.Entities.Dtos;
using FluentValidation;

namespace BuildingSystem.UI.Validations
{
    public class RoleDtoValidator: AbstractValidator<RoleDto>
    {
        public RoleDtoValidator()
        {
            RuleFor(x => x.RoleName).NotEmpty().WithMessage("Bu Alan Boş Geçilemez.").MaximumLength(15).WithMessage("Fazla Karakter Gridiniz.");
            RuleFor(x => x.RoleName).MaximumLength(15).WithMessage("Fazla Karakter Gridiniz.");
            RuleFor(x => x.RoleName).MinimumLength(5).WithMessage("En az 5 Karakter Giriniz.");
        }
    }
}
