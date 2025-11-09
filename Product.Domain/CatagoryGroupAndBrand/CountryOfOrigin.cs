using Product.Domain.Common;
using Product.Domain.Products;

namespace Product.Domain.CatagoryGroupAndBrand
{
    public class CountryOfOrigin : IAuditable
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string ZCode { get; private set; }


        public DateTime CreatedAt { get; private set; }
        public DateTime? LastUpdate { get; private set; }


        public ICollection<ProductItem> Products { get; set; }= new List<ProductItem>();
        private CountryOfOrigin() { }


        public CountryOfOrigin(string name, string zCode)
        {
            Name = name;
            ZCode = zCode;
            CreatedAt = DateTime.UtcNow;
        }
    }
}
