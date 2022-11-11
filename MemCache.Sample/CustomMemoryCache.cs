namespace MemCache.Sample
{
    using Microsoft.Extensions.Caching.Memory;

    public sealed class CustomMemoryCache
    {
        public MemoryCache Cache { get; } = new MemoryCache(new MemoryCacheOptions
        {
            // https://learn.microsoft.com/en-us/aspnet/core/performance/caching/memory?view=aspnetcore-7.0#use-setsize-size-and-sizelimit-to-limit-cache-size
            SizeLimit = 1024
        });
    }
}
