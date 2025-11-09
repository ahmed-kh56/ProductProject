using FluentValidation;

namespace Product.Application.Commands.Products.UpdateProduct
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEqual(Guid.Empty)
                .WithMessage("Product Id is required.");

            RuleFor(x => x.Name)
                .MinimumLength(3).When(x => !string.IsNullOrEmpty(x.Name))
                .WithMessage("Product Name must be at least 3 characters.")
                .MaximumLength(200).When(x => !string.IsNullOrEmpty(x.Name))
                .WithMessage("Product Name must not exceed 200 characters.");

            RuleFor(x => x.EnglishName)
                .MinimumLength(3).When(x => !string.IsNullOrEmpty(x.EnglishName))
                .WithMessage("Product English Name must be at least 3 characters.")
                .MaximumLength(200).When(x => !string.IsNullOrEmpty(x.EnglishName))
                .WithMessage("Product English Name must not exceed 200 characters.");

            RuleFor(x => x.SmallestUnitCost)
                .GreaterThanOrEqualTo(0)
                .When(x => x.SmallestUnitCost.HasValue)
                .WithMessage("Smallest Unit Cost must be greater than or equal to 0.");

            RuleFor(x => x.CatagoryId)
                .GreaterThan(0).When(x => x.CatagoryId.HasValue)
                .WithMessage("Category ID must be positive when provided.");

            RuleFor(x => x.BrandId)
                .GreaterThan(0).When(x => x.BrandId.HasValue)
                .WithMessage("Brand ID must be positive when provided.");

            RuleFor(x => x.ProductGroupId)
                .GreaterThan(0).When(x => x.ProductGroupId.HasValue)
                .WithMessage("Product Group ID must be positive when provided.");

            RuleFor(x => x.CountryOfOriginId)
                .GreaterThan(0).When(x => x.CountryOfOriginId.HasValue)
                .WithMessage("Country of Origin ID must be positive when provided.");

            RuleFor(x => x.MainTaxId)
                .NotEqual(Guid.Empty).When(x => x.MainTaxId.HasValue)
                .WithMessage("Main Tax ID must be positive when provided.");

            RuleFor(x => x.SubTaxId)
                .NotEqual(Guid.Empty).When(x => x.SubTaxId.HasValue)
                .WithMessage("Sub Tax ID must be positive when provided.");
        }
    }

}
