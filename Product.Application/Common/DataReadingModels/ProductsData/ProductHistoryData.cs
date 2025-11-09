using Product.Domain.CatagoryGroupAndBrand;
using Product.Domain.Products;
using Product.Domain.Taxes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Common.DataReadingModels.ProductsData
{
    public class ProductHistoryData
    {
        public ProductHistoryData(ProductItem item,DateTime ChangedAt, string action)
        {
            if (item != null)
            {
                From = item.LastUpdate ?? item.CreatedAt;
                To = ChangedAt;
                Product = new ProductHistoryDataNeeded(item);
                Action = action;
            }
            else
            {
                To = ChangedAt;
                Action = action;
            }

        }
        public ProductHistoryDataNeeded Product { get; set; } = null;
        public DateTime From { get; set; }
        public DateTime? To { get; set; } = null;
        public string Action { get; set; }
    }
}
