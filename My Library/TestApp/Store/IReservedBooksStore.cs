using My_Library.Model;

namespace My_Library.Store
{
    public interface IReservedBooksStore
    {
        event Action ReservedBooksUpdated;           // or with proper EventArgs
        event Action<IReservedBook> ReservedBookEdited;
        event Action<IReservedBook> ReservedBookAdded;
        event Action<IReservedBook> ReservedBookDeleted;
        IEnumerable<IReservedBook> ReservedBook { get; }

        Task AddReservBook(IReservedBook reservedBook);
        void Clear();
        Task DeleteReservBook(IReservedBook reservedBook);
        Task GetReservedBooksAsync(string customSql = "");

        Task Load();
        Task UpdateReservedBook(IReservedBook reservedBook);
    }
}