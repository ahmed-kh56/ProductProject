using Product.Domain.Barcodes;
using Product.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Domain.Common
{
    public static class DomainModelsNames
    {
        public const string ProductItemName = nameof(ProductItem);
        public const string BarcodeName = nameof(Barcode);
        public const string PriceAccordingToBranchName = nameof(PriceAccordingToBranch);
    }
}
