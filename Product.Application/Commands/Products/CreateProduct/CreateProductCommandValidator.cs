using FluentValidation;

namespace Product.Application.Commands.Products.CreateProduct
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Product name is required.")
                .MinimumLength(3).WithMessage("Product name must be at least 3 characters.")
                .MaximumLength(200).WithMessage("Product name must not exceed 200 characters.");

            RuleFor(x => x.EnglishName)
                .NotEmpty().WithMessage("English name is required.")
                .MinimumLength(3).WithMessage("English name must be at least 3 characters.")
                .MaximumLength(200).WithMessage("English name must not exceed 200 characters.");



            RuleFor(x => x.SmallestUnitCost)
                .GreaterThan(0).WithMessage("Smallest unit cost must be greater than zero.");

            RuleFor(x => x.CatagoryId)
                .GreaterThan(0).WithMessage("Category ID must be a positive integer.");

            RuleFor(x => x.BrandId)
                .GreaterThan(0).WithMessage("Brand ID must be a positive integer.");

            RuleFor(x => x.ProductGroupId)
                .GreaterThan(0).WithMessage("Product Group ID must be a positive integer.");

            RuleFor(x => x.CountryOfOriginId)
                .GreaterThan(0).WithMessage("Country of Origin ID must be a positive integer.");

            // Optional taxes
            RuleFor(x => x.MainTaxId)
                .NotEqual(Guid.Empty).When(x => x.MainTaxId.HasValue)
                .WithMessage("Main Tax ID must be positive when provided.");

            RuleFor(x => x.SubTaxId)
                .NotEqual(Guid.Empty).When(x => x.SubTaxId.HasValue)
                .WithMessage("Sub Tax ID must be positive when provided.");
        }
    }





}


