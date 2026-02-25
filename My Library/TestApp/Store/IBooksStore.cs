using My_Library.Model;

namespace My_Library.Store
{
    public interface IBooksStore
    {
        event Action BooksUpdated;
        event Action<IBook> BookAdded;
        event Action<IBook> BookEdited;
        event Action<IBook> BookDeleted;
        IEnumerable<IBook> Books { get; }
        string SearchBookName { get; set; }
        int SearchSubject { get; set; }

        Task AddNewBook(IBook book);
        void clear();
        Task DeleteBook(IBook book);
        Task EditBook(IBook book);
        Task GetAllBooks(string customSql = "");
        Task Load();
    }
}