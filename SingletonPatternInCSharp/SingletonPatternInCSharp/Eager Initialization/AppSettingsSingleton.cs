namespace SingletonPatternInCSharp.Eager_Initialization
{
    public class AppSettingsSingleton
    {
        // Eagerly created instance (thread-safe by default)
        private static readonly AppSettingsSingleton _instance = new AppSettingsSingleton();

        // Private constructor prevents external instantiation
        private AppSettingsSingleton()
        {
            AppName = "Eager Singleton Demo App";
            Version = "1.0.0";
            MaxUsers = 100;
        }

        public static AppSettingsSingleton Instance => _instance;

        // Example configuration properties
        public string AppName { get; }
        public string Version { get; }
        public int MaxUsers { get; }
    }
}
