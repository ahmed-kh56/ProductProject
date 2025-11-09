using Product.Domain.Common;
using Product.Domain.Products;

namespace Product.Domain.Suppliers
{
    public class ProductSupplier: IAuditable
    {
        public Guid Id { get; private set; }
        public Guid ProductId { get; private set; }
        public ProductItem Product { get; private set; }
        public Guid SupplierId { get; private set; }
        public Supplier Supplier { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? LastUpdate { get; private set; }


        private ProductSupplier()
        {
        }

        public ProductSupplier(Guid productId, Guid supplierId)
        {
            Id = Guid.NewGuid();
            ProductId = productId;
            SupplierId = supplierId;
            CreatedAt = DateTime.UtcNow;
        }
    }

}
