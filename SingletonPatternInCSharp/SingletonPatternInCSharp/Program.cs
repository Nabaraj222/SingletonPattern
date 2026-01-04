using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using SingletonPatternInCSharp.Dependency_Injection;
using SingletonPatternInCSharp.Double_Checked_Locking;
using SingletonPatternInCSharp.Eager_Initialization;
using SingletonPatternInCSharp.Lazy_Initialization;
using SingletonPatternInCSharp.Simple;
using SingletonPatternInCSharp.Static_Class;
using SingletonPatternInCSharp.Thread_Safe_using_Lock;

#region Simple Singleton
var config1 = AppConfigSingleton.Instance;
var config2 = AppConfigSingleton.Instance;

Console.WriteLine($"App: {config1.ApplicationName}");
Console.WriteLine($"Version: {config1.Version}");

// Both references point to the same instance
Console.WriteLine(ReferenceEquals(config1, config2)); // True
#endregion

#region Thread Safe Singleton with Lock
// Simulate multiple threads logging at the same time
Parallel.For(0, 5, i =>
{
    var logger = LoggerSingleton.Instance;
    logger.Log($"Message from task {i}");
});

// Verify single instance
var logger1 = LoggerSingleton.Instance;
var logger2 = LoggerSingleton.Instance;
Console.WriteLine(ReferenceEquals(logger1, logger2)); // True
#endregion

#region Double-Checked Locking Singleton
// Simulate multiple threads accessing the database manager
Parallel.For(0, 5, i =>
{
    var dbManager = DatabaseManagerSingleton.Instance;
    dbManager.ExecuteQuery($"SELECT * FROM Users WHERE Id = {i}");
});

// Verify single instance
var db1 = DatabaseManagerSingleton.Instance;
var db2 = DatabaseManagerSingleton.Instance;
Console.WriteLine(ReferenceEquals(db1, db2)); // True
#endregion

#region Eager Initialization Singleton
var settings1 = AppSettingsSingleton.Instance;
var settings2 = AppSettingsSingleton.Instance;

Console.WriteLine($"App: {settings1.AppName}");
Console.WriteLine($"Version: {settings1.Version}");
Console.WriteLine($"Max Users: {settings1.MaxUsers}");

// Verify both references point to the same instance
Console.WriteLine(ReferenceEquals(settings1, settings2)); // True
#endregion

#region Lazy Initialization Singleton
// Cache is NOT created yet
Parallel.For(0, 3, i =>
{
    var cache = CacheManagerSingleton.Instance;
    cache.Add($"key{i}", $"value{i}");
});

var cacheManager = CacheManagerSingleton.Instance;
Console.WriteLine(cacheManager.Get("key1"));
#endregion

#region Static Class based Singleton
SqlConnection connection1 = DatabaseConnectionProvider.GetConnection();
SqlConnection connection2 = DatabaseConnectionProvider.GetConnection();

Console.WriteLine(connection1.ConnectionString);
Console.WriteLine(connection2.ConnectionString);

// These are different objects, created by a static provider
Console.WriteLine(ReferenceEquals(connection1, connection2)); // False
#endregion

#region Singleton via Dependency Injection
// Create service collection
var services = new ServiceCollection();

// Register LoggerService as Singleton
services.AddSingleton<ILoggerService, LoggerService>();

// Build service provider
var serviceProvider = services.BuildServiceProvider();

// Resolve service multiple times
var singletonLogger1 = serviceProvider.GetRequiredService<ILoggerService>();
var singletonLogger2 = serviceProvider.GetRequiredService<ILoggerService>();

singletonLogger1.Log("First log message");
singletonLogger2.Log("Second log message");

// Verify singleton behavior
Console.WriteLine(ReferenceEquals(singletonLogger1, singletonLogger2)); // True
#endregion