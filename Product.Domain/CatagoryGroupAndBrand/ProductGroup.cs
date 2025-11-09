using Product.Domain.Common;
using Product.Domain.Products;

namespace Product.Domain.CatagoryGroupAndBrand
{
    public class ProductGroup : IAuditable
    {
        public int Id { get; private set; }
        public string Name { get; private set; }


        public DateTime CreatedAt { get; private set; }
        public DateTime? LastUpdate { get; private set; }


        public ICollection<ProductItem> Products { get; private set; }

    }
}
