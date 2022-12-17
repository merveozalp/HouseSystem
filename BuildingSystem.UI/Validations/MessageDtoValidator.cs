using BuildingSystem.Entities.Dtos;
using FluentValidation;

namespace BuildingManager.Web.ValidationRules.FluentValidation
{
    public class MessageDtoValidator : AbstractValidator<MessageDto>
    {
        public MessageDtoValidator()
        {
            RuleFor(x => x.MessageContent).NotNull().WithMessage(" Mesaj Ba�l��� Giriniz. ");
            RuleFor(x => x.MessageContent).MaximumLength(20).WithMessage("Mesaj Ba�l��� Karakter Say�s�na Dikkat Ediniz.");
            RuleFor(x => x.Body).MaximumLength(1000).WithMessage("Mesaj i�eri�iniz �ok Uzun");
            RuleFor(x => x.ReceiverMail).NotNull().WithMessage("L�tfen G�nderece�iniz Ki�iyi Giriniz.");
        }

    }
}