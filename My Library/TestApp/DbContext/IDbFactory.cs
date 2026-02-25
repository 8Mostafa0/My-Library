
namespace My_Library.DbContext
{
    public interface IDbFactory
    {
        Task CreateDatabaseAsync();
    }
}