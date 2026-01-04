namespace SingletonPatternInCSharp.Double_Checked_Locking
{
    public class DatabaseManagerSingleton
    {
        private static DatabaseManagerSingleton? _instance;
        private static readonly object _lock = new object();

        // Private constructor prevents external instantiation
        private DatabaseManagerSingleton()
        {
            // Simulate opening a database connection
            Console.WriteLine("Database connection initialized.");
        }

        public static DatabaseManagerSingleton Instance
        {
            get
            {
                // First check without locking (performance optimization)
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        // Double-check inside the lock
                        if (_instance == null)
                        {
                            _instance = new DatabaseManagerSingleton();
                        }
                    }
                }

                return _instance;
            }
        }

        // Example method to simulate database query
        public void ExecuteQuery(string query)
        {
            Console.WriteLine($"Executing query: {query}");
        }
    }
}
