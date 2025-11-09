using MediatR;
using OutcomeOf;
using Product.Application.Common.DataReadingModels.Supplayeres;
using Product.Application.Common.Interfaces;

namespace Product.Application.Queries.Supplayers.GetSupplayersByPhone
{
    public class GetSupplayersByPhoneQueryHandler 
        (IProductSupplayerRepository _supplayerRepository): IRequestHandler<GetSupplayersByPhoneQuery, OutcomeOf<IEnumerable<ProductSupplayerReadForm>>>
    {
        public async Task<OutcomeOf<IEnumerable<ProductSupplayerReadForm>>> Handle(GetSupplayersByPhoneQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var supplayers = await _supplayerRepository.GetByPhoneAsync(request.productId, request.PhoneNumLike);
                return supplayers.ToOutcomeOf();
            }
            catch (Exception ex)
            {
                return Error.Failure(description: ex.Message);
            }

        }
    }
}
