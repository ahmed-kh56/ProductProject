using Product.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Domain.Suppliers
{
    public class Supplier : IAuditable
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string ContactPhone { get; private set; }

        public SupplierScope Scope { get; private set; } = SupplierScope.Local;
        public DateTime CreatedAt { get; private set; }
        public DateTime? LastUpdate { get; private set; }
        public ICollection<ProductSupplier> ProductSuppliers { get; private set; }= new List<ProductSupplier>();
        private Supplier() { }

        public Supplier(string name, string contactPhone, SupplierScope scope, DateTime createdAt, DateTime? lastUpdate)
        {
            Id = Guid.NewGuid();
            Name = name;
            ContactPhone = contactPhone;
            Scope = scope;
            CreatedAt = createdAt;
            LastUpdate = lastUpdate;
        }
    }

}
