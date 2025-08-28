using FluentValidation;
using Frontend.Models;

namespace Frontend.Validators
{
    internal sealed class QueryParametersValidator : AbstractValidator<QueryParameters>
    {
        public QueryParametersValidator()
        {
            //Dates
            RuleFor(f => f.DateTo).Must((parameters, dateTo) => dateTo >= parameters.DateFrom)
                .When(parameters => parameters.ExactDate == null && parameters.DateFrom != null && parameters.DateTo != null);
            RuleFor(f => f.DateTo).Must(dateTo => dateTo == null)
                .When(parameters => parameters.ExactDate != null);
            RuleFor(f => f.DateFrom).Must(dateFrom => dateFrom == null)
                .When(parameters => parameters.ExactDate != null);

            //Integers
            RuleFor(f => f.MinQuantity)
                .Must((parameters, min) => min <= parameters.MaxQuantity).When(parameters => parameters.MaxQuantity != -1);
        }
    }
}