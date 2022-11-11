namespace MemCache.Sample
{
    public class CacheSettings
    {
        public bool UseDistributedCache { get; set; }
        public bool PreferRedis { get; set; }
        public string? RedisUrl { get; set; }
    }
}
