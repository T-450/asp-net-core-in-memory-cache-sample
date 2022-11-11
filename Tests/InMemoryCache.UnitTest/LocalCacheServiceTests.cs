namespace InMemoryCache.UnitTest
{
    using MemCache.Sample;
    using Microsoft.Extensions.DependencyInjection;
    using Xunit;

    public sealed class LocalCacheServiceTests : CacheServiceTests, IClassFixture<CustomWebApplicationFactory<Program>>
    {
        public LocalCacheServiceTests(CustomWebApplicationFactory<Program> factory)
            : base(factory.Services.GetRequiredService<LocalCacheService>())
        {
        }
    }
}
