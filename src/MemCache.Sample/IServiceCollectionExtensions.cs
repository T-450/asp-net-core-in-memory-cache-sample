namespace MemCache.Sample
{
    using Microsoft.Extensions.Caching.Memory;

    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCaching(this IServiceCollection services, IConfiguration config)
        {
            services.AddMemoryCache()
                .AddTransient<IMemoryCache, MemoryCache>()
                .AddTransient<LocalCacheService>()
                .AddTransient<ICacheService, LocalCacheService>();
            _ = services.BuildServiceProvider();
            return services;
        }
    }
}
