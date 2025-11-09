namespace Product.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentationLayer(this IServiceCollection services)
        {

            services.AddControllers();
            services.AddOpenApi();
            services.AddSwaggerGen();
            services.AddEndpointsApiExplorer();

            return services;
        }
    }
}
