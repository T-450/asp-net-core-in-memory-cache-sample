namespace Distributed.Redis.Sample
{
    using InMemoryCache.UnitTest;

    public class LocalCacheServiceTests : CacheServiceTests
    {
        public LocalCacheServiceTests(LocalCacheService cacheService)
            : base(cacheService)
        {
        }
    }
}
