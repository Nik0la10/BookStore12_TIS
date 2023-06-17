using BookStore.Models.Request;
using FluentValidation;
using FluentValidation.AspNetCore;
using System.Linq.Expressions;

namespace BookStore.Controllers.Validators
{
    public class AddAuthorRequestValidator : 
        AbstractValidator<AddAuthorRequest>
    {
        public AddAuthorRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotNull().WithMessage("Pishi")
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(10);

            RuleFor(x => x.Bio)
                .NotEmpty();
        }

    }
}
