namespace InMemory
{
    using Distributed.Redis.Sample;

    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCaching(this IServiceCollection services, IConfiguration config)
        {
            services.AddDistributedMemoryCache();
            services.AddTransient<ICacheService, LocalCacheService>();

            return services;
        }
    }
}
