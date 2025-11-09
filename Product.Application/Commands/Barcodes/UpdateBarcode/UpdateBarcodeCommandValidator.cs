using FluentValidation;

namespace Product.Application.Commands.Barcodes.UpdateBarcode
{
    public class UpdateBarcodeCommandValidator : AbstractValidator<UpdateBarcodeCommand>
    {
        public UpdateBarcodeCommandValidator()
        {
            RuleFor(x => x.Code)
                .NotEmpty().WithMessage("Barcode code is required.")
                .MaximumLength(100).WithMessage("Barcode code cannot exceed 100 characters.");
            RuleFor(x => x.Code).Matches("^[0-9]+$").WithMessage("Barcode code must be alphanumeric.");



            RuleFor(x => x.UnitsCountPerPackage)
                .GreaterThan(0)
                .When(x => x.UnitsCountPerPackage.HasValue)
                .WithMessage("Units count per package must be greater than 0.");

            RuleFor(x => x.ProfitMargin)
                .GreaterThanOrEqualTo(0)
                .When(x => x.ProfitMargin.HasValue)
                .WithMessage("Profit margin cannot be negative.");

            RuleFor(x => x.WholesaleProfitMargin)
                .GreaterThanOrEqualTo(0)
                .When(x => x.WholesaleProfitMargin.HasValue)
                .WithMessage("Wholesale profit margin cannot be negative.");
        }
    }

}
