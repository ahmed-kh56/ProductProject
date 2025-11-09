using Product.Domain.Suppliers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Common.DataReadingModels.Supplayeres
{
    public class ProductSupplayerReadForm
    {
        public Guid Id { get; set; }

        public Guid ProductId { get; set; }

        public Guid SupplayerId { get; set; }

        public string SupplayerName { get; set; } = string.Empty;

        public SupplierScope SupplayerScope { get; set; }

        public string SupplayerPhone { get; set; } = string.Empty;

        public bool IsSupplyingProduct { get; set; }
    }

}
