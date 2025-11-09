using FluentValidation;

namespace Product.Application.Queries.Supplayers.GetSupplayersByPhone
{
    public class GetSupplayersByPhoneQueryValidator:AbstractValidator<GetSupplayersByPhoneQuery>
    {
        public GetSupplayersByPhoneQueryValidator()
        {
            RuleFor(q=>q.PhoneNumLike).MinimumLength(3).MaximumLength(16).When(q=>q.PhoneNumLike?.Length>0);
        }

    }


}
