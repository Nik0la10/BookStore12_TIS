using BookStore.Models.Request;
using FluentValidation;

namespace BookStore.Controllers.Validators
{
    public class AddBookRequestValidator :
        AbstractValidator<AddBookRequest>
    {
            public AddBookRequestValidator()
            {
                RuleFor(x => x.Name)
                    .NotNull().WithMessage("Pishi neshto")
                    .NotEmpty()
                    .MinimumLength(2)
                    .MaximumLength(10);

                RuleFor(x => x.Description)
                    .NotEmpty();
            } 
    }
}
