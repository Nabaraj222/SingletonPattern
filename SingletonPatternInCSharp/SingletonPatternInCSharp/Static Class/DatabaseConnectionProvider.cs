using Microsoft.Data.SqlClient;

namespace SingletonPatternInCSharp.Static_Class
{
    public static class DatabaseConnectionProvider
    {
        private static readonly string _connectionString =
            "Server=localhost;Database=AppDb;Trusted_Connection=True;";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
