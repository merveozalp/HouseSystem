using BuildingSystem.Entities.Dtos;
using FluentValidation;

namespace BuildingManager.Web.ValidationRules.FluentValidation
{
    public class UserDtoValidator : AbstractValidator<UserDto>
    {
        public UserDtoValidator()
        {
            RuleFor(x => x.FirstName).NotNull().WithMessage("Ýsminizi Giriniz.");
            RuleFor(x => x.FirstName).MaximumLength(200).WithMessage("Karakter sayýnýz fazla kontrol ediniz.");
            RuleFor(x => x.LastName).NotNull().WithMessage("Lütfen Soyisminizi Giriniz.");
            RuleFor(x => x.LastName).MaximumLength(200).WithMessage("Karakter sayýnýz fazla kontrol ediniz ");
            RuleFor(x => x.UserName).NotNull().WithMessage("Lütfen Kullanýcý Ýsminizi Giriniz.");
            RuleFor(x => x.UserName).MaximumLength(50).WithMessage("Kullanýcý Adý uzunluðunuz Fazla Kontrol Ediniz.");
            RuleFor(x => x.Email).NotNull().WithMessage("Email Adresini Boþ Geçemezsiniz.");
            RuleFor(x => x.Email).EmailAddress().WithMessage(" Email Adresinizi Doðru Giriniz.");
            RuleFor(x => x.IdentityNo).NotNull().WithMessage("Lütfen Kimlik Numaranýzý Yazýnýz.");
            RuleFor(x => x.IdentityNo).MaximumLength(11).WithMessage("Kimlik Numaranýzýn uzunluðuna Dikkat Ediniz.");
            RuleFor(x => x.CarNo).NotNull().WithMessage("Araba Plakanýzý Giriniz. ");
            RuleFor(x => x.CarNo).MaximumLength(10).WithMessage("Araba Plaka Uzunluðunuzu Kontrol Ediniz.");
            RuleFor(x => x.Password).MaximumLength(10).WithMessage("Lütfen þifre giriniz..");
        }
    }
}