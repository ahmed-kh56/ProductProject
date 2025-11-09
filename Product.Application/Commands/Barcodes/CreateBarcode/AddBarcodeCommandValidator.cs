using FluentValidation;

namespace Product.Application.Commands.Barcodes.CreateBarcode
{
    public class CreateBarcodeCommandValidator : AbstractValidator<CreateBarcodeCommand>
    {
        public CreateBarcodeCommandValidator()
        {
            RuleFor(x => x.ProductId)
                .NotEmpty().WithMessage("Product Id is required.")
                .NotEqual(Guid.Empty).WithMessage("Product Id cannot be empty.");

            RuleFor(x => x.Code)
                .NotEmpty().WithMessage("Barcode code is required.")
                .MaximumLength(100).WithMessage("Barcode code cannot exceed 100 characters.");
            RuleFor(x => x.Code).Matches("^[0-9]+$").WithMessage("Barcode code must be alphanumeric.");


            RuleFor(x => x.UnitId)
                .GreaterThan((byte)0).WithMessage("Unit Id must be greater than 0.");

            RuleFor(x => x.UnitsCountPerPackage)
                .GreaterThan(0).WithMessage("Units count per package must be greater than 0.");

            RuleFor(x => x.ProfitMargin)
                .GreaterThanOrEqualTo(0).WithMessage("Profit margin cannot be negative.");

            RuleFor(x => x.WholesaleProfitMargin)
                .GreaterThanOrEqualTo(0).WithMessage("Wholesale profit margin cannot be negative.");

            RuleFor(x => x.SmallestUnitPrice)
                .GreaterThan(0).WithMessage("Smallest unit price must be greater than 0.");

            RuleFor(x => x.LowestPriceForSalePerSmallestUnit)
                .GreaterThan(0)
                .When(x => x.LowestPriceForSalePerSmallestUnit > 0)
                .WithMessage("Lowest price for sale per smallest unit must be greater than 0.");

            RuleFor(x => x.WholesaleProfitMargin)
                .LessThanOrEqualTo(x => x.ProfitMargin + 100)
                .WithMessage("Wholesale profit margin should be reasonable compared to the profit margin.");
        }
    }

}
