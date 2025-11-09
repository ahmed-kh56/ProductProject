using Product.Domain.Barcodes;

namespace Product.Application.Common.Interfaces
{
    public interface IBarcodeWriteRepository
    {
        
        Task<Barcode?> GetByCodeAsync(string code);

        Task AddAsync(Barcode barcode);
        void Update(Barcode barcode);
        void Delete(Barcode barcode);
        Task<IEnumerable<Barcode>> GetBarcodesByProductIdAsync(Guid productId);
        void DeleteBulk(IEnumerable<Barcode> barcodes);
        void AttachRangeAsUnChanged(IEnumerable<Barcode> barcodes);
    }
}
