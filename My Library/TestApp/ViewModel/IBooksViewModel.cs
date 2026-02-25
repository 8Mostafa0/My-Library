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
        ICommand DeleteBookCommand { get; }
        ICommand EditBookCommand { get; }
        ICommand LoadBooksCommand { get; }
        string Name { get; set; }
        ICommand OrderBooksCommand { get; }
        string PublicationDate { get; set; }
        string Publisher { get; set; }
        ICommand ReloadClientsCommand { get; }
        IBook SelectedBook { get; set; }
        int SortIndex { get; set; }
        string Subject { get; set; }
        int Tier { get; set; }

        static abstract IBooksViewModel LoadViewModel(IBooksStore booksStore, ILoanRepository loanRepository, IReservedBooksRepository reservedBooksRepository, BooksRepository booksRepository);
        void AddNewBook(IBook book);
        void UpdateBooks();
    }
}