using FluentValidation;

namespace Product.Application.Queries.Barcodes.GetProductBarcodes
{
    public class GetBarcodesByProductIdQueryValidator:AbstractValidator<GetBarcodesByProductIdQuery>
    {
        public GetBarcodesByProductIdQueryValidator()
        {
            RuleFor(x => x.ProductId)
                .NotEmpty().NotEqual(Guid.Empty)
                .WithMessage("ProductId must be provided.");

            RuleFor(x => x.BranchId)
                .GreaterThanOrEqualTo(0)
                .WithMessage("BranchId must be greater than or equal to 0.");
        }
    }


}
