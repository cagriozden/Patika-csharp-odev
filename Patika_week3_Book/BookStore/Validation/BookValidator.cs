using FluentValidation;

namespace BookStore.Validators
{
    public class BookValidator : AbstractValidator<Book>
    {
        public BookValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .WithMessage("Başlık alanı zorunludur");

            RuleFor(x => x.PageCount)
                .GreaterThan(0)
                .WithMessage("Sayfa sayısı sıfırdan büyük olmalıdır.");

            RuleFor(x => x.GenreId)
                .NotEmpty()
                .WithMessage("Tür Kimliği alanı zorunludur.");
        }

    }
}
