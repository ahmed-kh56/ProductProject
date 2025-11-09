using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage;
using Product.Application.Common.Helpers;
using Product.Application.Common.Interfaces;
using Product.Domain.Barcodes;
using Product.Domain.Branchs;
using Product.Domain.CatagoryGroupAndBrand;
using Product.Domain.Common;
using Product.Domain.Products;
using Product.Domain.Suppliers;
using Product.Domain.Taxes;
using System.Data;
using System.Reflection.Emit;
using System.Text.Json;

namespace Product.Infrastructure.Persistence
{
    public class ProductServiceDbContext : DbContext, IUnitOfWork
    {
        private IDbContextTransaction _dbTransaction;
        public ProductServiceDbContext(DbContextOptions<ProductServiceDbContext> options) : base(options)
        {
        }

        public DbSet<Catagory> Catagories { get; set; }
        public DbSet<ProductGroup> ProductGroups { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<ProductItem> Products { get; set; }
        public DbSet<ProductSupplier> ProductSuppliers { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Barcode> Barcodes { get; set; }
        public DbSet<Tax> Taxes { get; set; }
        public DbSet<UnitOfMeasurement> UnitOfMeasurement { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<CountryOfOrigin> CountriesOfOrigin { get; set; }
        public DbSet<PriceAccordingToBranch> PricesByBranches { get; set; }
        private DbSet<AuditLog> AuditLogs { get; set; }

        public DbSet<AuditLog> Logs => AuditLogs;




        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var auditableEntries = ChangeTracker.Entries()
                .Where(e => e.Entity is IAuditable &&
                           (e.State == EntityState.Modified ||
                            e.State == EntityState.Deleted ||
                            e.State == EntityState.Added))
                .ToList();

            var logs = GetDataLogs(auditableEntries);
            Logs.AddRange(logs);

            return await base.SaveChangesAsync(cancellationToken);
        }


        private List<AuditLog> GetDataLogs(List<EntityEntry> auditableEntries)
        {
            if (auditableEntries is null || auditableEntries.Count == 0)
                return new List<AuditLog>();

            var logs = new List<AuditLog>();

            foreach (var entry in auditableEntries)
            {
                var entity = entry.Entity;
                var entityName = entity.GetType().Name;
                var action = entry.State.ToString();


                string? entityId = entry.Entity switch
                {
                    Barcode barcode => barcode.Code,
                    PriceAccordingToBranch price => $"{price.BarcodeCode}-{price.BranchId.ToString()}",
                    _ => entry.Property("Id").CurrentValue.ToString() ?? entry.Property("Id").OriginalValue.ToString()
                };


                string? oldValues = null;

                if (entry.State == EntityState.Modified || entry.State == EntityState.Deleted)
                {
                    var dict = entry.OriginalValues.Properties.ToDictionary(
                        p => p.Name,
                        p => entry.OriginalValues[p.Name]
                    );
                    oldValues = dict.Serialize();
                }

                logs.Add(new AuditLog(
                    entityName,
                    entityId,
                    action,
                    oldValues
                ));
            }

            return logs;
        }






        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductServiceDbContext).Assembly);


            base.OnModelCreating(modelBuilder);
        }

        public async Task<int> SaveEntitiesAsync()
        {
            return await SaveChangesAsync();
        }


        public async Task StartTransactionAsync()
        {
            if (_dbTransaction == null)
            {
                _dbTransaction = await Database.BeginTransactionAsync();
            }
        }

        public async Task CommitTransactionAsync()
        {


            if (_dbTransaction != null)
            {
                await _dbTransaction.CommitAsync();
                await _dbTransaction.DisposeAsync();
                _dbTransaction = null;
            }
        }


    }
}
