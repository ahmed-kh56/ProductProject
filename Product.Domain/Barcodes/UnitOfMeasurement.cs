using Product.Domain.Common;

namespace Product.Domain.Barcodes
{
    public class UnitOfMeasurement: IAuditable
    {
        public byte Id { get; private set; }
        public string UnitName { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? LastUpdate { get; private set; }

        public ICollection<Barcode> Barcodes { get; private set; } = new List<Barcode>();
        private UnitOfMeasurement() { }

        public UnitOfMeasurement(byte id, string unitName)
        {
            Id = id;
            UnitName = unitName;
        }
    }
}
