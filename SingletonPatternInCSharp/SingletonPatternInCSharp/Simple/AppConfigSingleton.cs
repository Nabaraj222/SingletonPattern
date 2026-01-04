namespace SingletonPatternInCSharp.Simple
{
    /// <summary>
    /// Basic singleton implementation - NOT thread-safe!
    /// Demonstrates the simplest form of singleton pattern.
    /// </summary>
    public class AppConfigSingleton
    {
        private static AppConfigSingleton? _instance;

        // Private constructor
        private AppConfigSingleton()
        {
            ApplicationName = "Singleton Demo App";
            Version = "1.0.0";
        }

        public static AppConfigSingleton Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new AppConfigSingleton();
                }

                return _instance;
            }
        }

        public string ApplicationName { get; }
        public string Version { get; }
    }
}
