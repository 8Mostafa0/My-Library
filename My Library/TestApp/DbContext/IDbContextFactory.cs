using Microsoft.Data.SqlClient;

namespace My_Library.DbContext
{
    public interface IDbContextFactory
    {
        Task CheckDatabaseExistsAsync();
        Task ExecuteQueryAsync(string sqlQuery, string executePart);
        SqlConnection? GetConnection(string databaseName = "MyLibrary", bool withDb = true);
    }
}