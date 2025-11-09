using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Product.Application.Common.Interfaces;
using Product.Infrastructure.Persistence;
using Product.Infrastructure.Persistence.DbSettings;
using Product.Infrastructure.Persistence.repositries.Auditrepositries;
using Product.Infrastructure.Persistence.repositries.Barcderepositries;
using Product.Infrastructure.Persistence.repositries.Productrepositries;
using Product.Infrastructure.Persistence.repositries.ReadingRepos;
using Product.Infrastructure.Persistence.repositries.Supplayersrepositries;

namespace Product.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddPersistence(configuration);
            return services;
        }
        private static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ProductServiceDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("Writing")));
            services.AddSingleton<IDbSettings>(new ReadingDbSettings
            {
                ConnectionString = configuration.GetConnectionString("Reading")
            });


            services.AddScoped<ICatagoryReadRepository, CatagoryReadRepository>();
            services.AddScoped<IProductGroupReadRepository, ProductGroupReadRepository>();
            services.AddScoped<IBrandReadRepository, BrandReadRepository>();
            services.AddScoped<IBrancheReadRepository, BrancheReadRepository>();
            services.AddScoped<ICountryOfOriginReadRepository, CountryOfOriginReadRepository>();
            services.AddScoped<IProductReadRepository, ProductReadRepository>();
            services.AddScoped<IProductSupplayerRepository, ProductSupplayerRepository>();
            services.AddScoped<ITaxesReadRepository, TaxesReadRepository>();
            services.AddScoped<IAuditLogRepository, AuditLogRepository>();
            services.AddScoped<IBarcodeReadRepository, BarcodeReadRepository>();
            services.AddScoped<IPriceReadRepository, PriceReadRepository>();





            services.AddScoped<IProductWriteRepository, ProductWriteRepository>();
            services.AddScoped<IPriceWriteRepository, PriceWriteRepository>();
            services.AddScoped<IBarcodeWriteRepository, BarcodeWriteRepository>();


            DapperTypeHandlerConfiguration.Register();

            services.AddScoped<IUnitOfWork>(provider =>
                    provider.GetRequiredService<ProductServiceDbContext>());



            return services;
        }
    }

}
