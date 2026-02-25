using My_Library.Command.BooksCommands;
using My_Library.Model;
using My_Library.Service;
using My_Library.Store;
using System.Windows.Input;

namespace My_Library.ViewModel
{
    public interface IBooksViewModel : IViewModelBase
    {
        ICommand AddNewBookCommand { get; }
        IEnumerable<IBook> Books { get; }
        IDeleteBookCommand DeleteBookCommand { get; }
        IEditBookCommand EditBookCommand { get; }
        ILoadBooksCommand LoadBooksCommand { get; }
        string Name { get; set; }
        IOrderBooksByStateCommand OrderBooksCommand { get; }
        string PublicationDate { get; set; }
        string Publisher { get; set; }
        IReloadBooksCommand ReloadBooksCommand { get; }
        IBook SelectedBook { get; set; }
        int SortIndex { get; set; }
        string Subject { get; set; }
        int Tier { get; set; }

        static abstract IBooksViewModel LoadViewModel(IBooksStore booksStore, ILoanRepository loanRepository, IReservedBooksRepository reservedBooksRepository, IBooksRepository booksRepository);
        void AddNewBook(IBook book);
        void UpdateBooks();
    }
}