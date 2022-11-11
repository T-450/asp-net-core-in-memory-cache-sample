namespace InMemoryCache.UnitTest
{
    using MemCache.Sample;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc.Testing;
    using Microsoft.Extensions.Caching.Memory;
    using Microsoft.Extensions.DependencyInjection;

    public class CustomWebApplicationFactory<TEntryPoint> : WebApplicationFactory<TEntryPoint>
        where TEntryPoint : Program
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(s =>
            {
                s.AddMemoryCache()
                    .AddTransient<IMemoryCache, MemoryCache>()
                    .AddTransient<LocalCacheService>()
                    .AddTransient<ICacheService, LocalCacheService>();

                _ = s.BuildServiceProvider();
            });
            builder.UseEnvironment("Development");

        }
    }
}
