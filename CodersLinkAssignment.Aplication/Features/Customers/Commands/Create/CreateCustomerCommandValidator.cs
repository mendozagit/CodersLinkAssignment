using FluentValidation;

namespace CodersLinkAssignment.Aplication.Features.Customers.Commands.Create
{
    public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerCommandValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .WithMessage("{PropertyName} Canot be empty")
                .MaximumLength(80)
                .WithMessage("{PropertyName} Canot be bigger than {MaxLength} chars.");

            RuleFor(x => x.LastName)
                .NotEmpty()
                .WithMessage("{PropertyName} Canot be empty")
                .MaximumLength(80)
                .WithMessage("{PropertyName} Canot be bigger than {MaxLength} chars.");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty()
                .WithMessage("{PropertyName} Canot be empty")
                .MaximumLength(10)
                .WithMessage("{PropertyName} Canot be bigger than {MaxLength} chars.");


            RuleFor(x => x.Email)
                .EmailAddress();
        }
    }
}
