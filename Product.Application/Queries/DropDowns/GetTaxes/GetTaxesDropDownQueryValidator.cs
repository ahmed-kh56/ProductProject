using FluentValidation;

namespace Product.Application.Queries.DropDowns.GetTaxes
{
    public class GetTaxesDropDownQueryValidator : AbstractValidator<GetTaxesDropDownQuery>
    {
        IReadOnlyList<string> TaxesTypes =new List<string> 
        {
            "SubTax",
            "Tax",
            "All"
        };
        public GetTaxesDropDownQueryValidator()
        {
            RuleFor(r => r.TaxType)
                .Must(type=> TaxesTypes.Contains(type))
                .WithMessage(@"Type must be one of 'All' ,'SubTax' or 'Tax' ");
        }
    }
}
