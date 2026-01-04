namespace SingletonPatternInCSharp.Thread_Safe_using_Lock
{
    public class LoggerSingleton
    {
        private static LoggerSingleton? _instance;
        private static readonly object _lock = new object();

        // Private constructor prevents external instantiation
        private LoggerSingleton() { }

        public static LoggerSingleton Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new LoggerSingleton();
                    }
                    return _instance;
                }
            }
        }

        // Example method for logging
        public void Log(string message)
        {
            Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] {message}");
        }
    }
}
