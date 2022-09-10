using FluentValidation;
using Graphql_CURD.Data;

namespace Graphql_CURD.Validators
{
    public class CakeInputTypeValidator : AbstractValidator<Cakes>
    {
        public CakeInputTypeValidator()
        {
            RuleFor(c => c.Name)
                .MinimumLength(3)
                .MaximumLength(30)
                .WithMessage("Name must be between 3 and 30 characters");

        }
    }
}
