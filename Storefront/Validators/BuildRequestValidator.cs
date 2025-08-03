using FluentValidation;
using Storefront.Models;

namespace Storefront.Validators
{
    public class BuildRequestValidator : AbstractValidator<BuildRequest>
    {
        public BuildRequestValidator()
        {
            RuleFor(r => r.Quantity).GreaterThan(0).LessThan(10000000);
            RuleFor(r => r.Dialect).IsInEnum();
        }
    }
}
