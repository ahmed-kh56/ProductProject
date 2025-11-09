using Product.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Common.DataReadingModels.ProductsData
{



    public class ProductDetailsReadModel
    {
        public Guid ProductId { get; set; }

        public string ProductName { get; set; }
        public string ProductEnglishName { get; set; }

        public decimal SmallestUnitCost { get; set; }

        public bool IsActive { get; set; }
        public bool IsAllowedOnline { get; set; }

        public ItemTransactionType TransactionType { get; set; }
        public ItemReceiptType ReceiptType { get; set; }

        public int CatagoryId { get; set; }
        public string CatagoryName { get; set; }

        public int BrandId { get; set; }
        public string BrandName { get; set; }

        public int GroupId { get; set; }
        public string GroupName { get; set; }

        public int CountryId { get; set; }
        public string CountryName { get; set; }

        public Guid? MainTaxId { get; set; }
        public string? MainTaxName { get; set; }
        public decimal? MainTaxRate { get; set; }

        public Guid? SubTaxId { get; set; }
        public string? SubTaxName { get; set; }
        public decimal? SubTaxRate { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? LastUpdate { get; set; }
    }



}
