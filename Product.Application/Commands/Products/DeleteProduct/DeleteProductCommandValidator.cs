using FluentValidation;

namespace Product.Application.Commands.Products.DeleteProduct
{
    public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
    {
        public DeleteProductCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().NotEqual(Guid.Empty).WithMessage("Product Id is required.");
        }
    }
}
