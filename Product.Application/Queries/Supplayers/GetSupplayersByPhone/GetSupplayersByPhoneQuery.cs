using MediatR;
using OutcomeOf;
using Product.Application.Common.DataReadingModels.Supplayeres;

namespace Product.Application.Queries.Supplayers.GetSupplayersByPhone
{
    public record GetSupplayersByPhoneQuery(
        Guid? productId,
        string PhoneNumLike,
        string Name)
        :IRequest<OutcomeOf<IEnumerable<ProductSupplayerReadForm>>>;
}
