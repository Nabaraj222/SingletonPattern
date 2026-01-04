namespace SingletonPatternInCSharp.Lazy_Initialization
{
    public class CacheManagerSingleton
    {
        private static readonly Lazy<CacheManagerSingleton> _instance =
            new Lazy<CacheManagerSingleton>(() => new CacheManagerSingleton());

        // Private constructor
        private CacheManagerSingleton()
        {
            Console.WriteLine("Cache Manager initialized.");
            _cache = new Dictionary<string, string>();
        }

        public static CacheManagerSingleton Instance => _instance.Value;

        private readonly Dictionary<string, string> _cache;

        public void Add(string key, string value)
        {
            _cache[key] = value;
        }

        public string Get(string key)
        {
            return _cache.TryGetValue(key, out var value)
                ? value
                : "Not Found";
        }
    }
}
