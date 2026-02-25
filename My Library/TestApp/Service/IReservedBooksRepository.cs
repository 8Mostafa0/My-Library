using My_Library.Model;

namespace My_Library.Service
{
    public interface IReservedBooksRepository
    {
        Task AddNewReservedBookToDb(IReservedBook reservedBook);
        Task<ReservedBook?> BookAlreadyRegistred(int bookId);
        Task DeleteReservedBookToDb(int bookId);
        Task DeleteReservedBookWithClientToDb(IReservedBook reservedBook);
        Task EditReservBookToDb(IReservedBook reservedBook);
        Task<List<ReservedBook>> GetAllReservedBooks(string customSql = "");
        Task<List<ReservedBook>> GetReservationForBook(int bookId);
        Task<ReservedBook> GetReservedBook(string customSql, string executionPart);
        Task RemoveClientReservedBooks(int clientId);
        Task<ReservedBook?> UserHaveReservedBook(int clientId);
    }
}