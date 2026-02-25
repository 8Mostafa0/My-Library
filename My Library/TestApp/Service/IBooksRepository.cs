using My_Library.Model;

namespace My_Library.Service
{
    public interface IBooksRepository
    {
        Task AddNewBookToDb(IBook book);
        Task DeleteBookInDb(IBook book);
        Task EditeBookInDb(IBook book);
        Task<List<Book>> GetAllBooks(string customSql = "");
        Task<IBook> GetBookById(int id, string customSql);
        Task<List<Book>> GetBooksByName(string bookName);
    }
}