using FluentValidation;


namespace Product.Application.Queries.Products.GetProductsHistory
{
    public class GetProductHistoryQueryValidator : AbstractValidator<GetProductHistoryQuery>
    {
        public GetProductHistoryQueryValidator()
        {
            RuleFor(x => x.PageSize)
                .GreaterThan(0).WithMessage("PageSize must be greater than 0.")
                .LessThanOrEqualTo(100).WithMessage("PageSize cannot exceed 100.");

            RuleFor(x => x.PageNum)
                .GreaterThanOrEqualTo(0).WithMessage("PageNum must be 0 or greater.");

            RuleFor(x => x.Id)
                .NotEmpty().When(x => x.Id.HasValue)
                .WithMessage("Id cannot be empty if provided.");

            RuleFor(x => new { x.IncludeUpdates, x.IncludeAdds, x.IncludeDeletes })
                .Must(x => x.IncludeUpdates || x.IncludeAdds || x.IncludeDeletes)
                .WithMessage("At least one inclusion flag must be true (Updates, Adds, or Deletes).");
        }
    }
}
