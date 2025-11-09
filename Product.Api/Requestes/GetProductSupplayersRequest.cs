using MediatR;
using Product.Application.Queries.Supplayers.GetSupplayersByPhone;

namespace Product.Api.Requestes
{
    public class GetProductSupplayersRequest
    {
        public string? PhoneLike { get; set; }
        public string? Name { get; set; }

        internal GetSupplayersByPhoneQuery ToQuery(Guid? ProductId= null)
        {
            return new GetSupplayersByPhoneQuery(ProductId, PhoneLike,Name);
        }
    }

}
