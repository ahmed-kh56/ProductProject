using Product.Domain.Common;
using Product.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Domain.Taxes
{
    public class Tax : IAuditable
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Rate { get; private set; }
        public TaxType TaxType { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? LastUpdate { get; private set; }

        public ICollection<ProductItem> MainTaxedproducts { get; private set; } = new List<ProductItem>();
        public ICollection<ProductItem> SubTaxedProduct { get; private set; } = new List<ProductItem>();
        private Tax() { }

        public Tax(Guid id, string name, string description, decimal rate, TaxType taxType)
        {
            Id = id;
            Name = name;
            Description = description;
            Rate = rate;
            this.TaxType = taxType;
            CreatedAt = DateTime.UtcNow;
        }
    }
}
