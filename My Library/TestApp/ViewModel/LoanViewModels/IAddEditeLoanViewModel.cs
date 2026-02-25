using My_Library.Model;
using My_Library.Service;
using My_Library.Store;
using System.Windows.Input;

namespace My_Library.ViewModel.LoanViewModels
{
    public interface IAddEditeLoanViewModel : IViewModelBase
    {
        IEnumerable<IBook> Books { get; }
        string BookSearch { get; set; }
        int BooksSortOrder { get; set; }
        IEnumerable<IClient> Clients { get; }
        string ClientSearch { get; set; }
        ICommand CloseModalCommand { get; }
        IViewModelBase CurrentModelViewModel { get; }
        ICommand LoadBooksCommand { get; }
        ICommand LoadClientsCommand { get; }
        ICommand OrderBooksBySubjectCommand { get; }
        DateTime ReturnDate { get; set; }
        ICommand SaveLoanDataCommand { get; }
        ICommand SearchBookNameCommand { get; }
        ICommand SearchClientNameCommand { get; }
        IBook SelectedBook { get; set; }
        IClient SelectedClient { get; set; }
        ILoan SelectedLoan { get; set; }
        string TitleOfLoanScreen { get; set; }

        static abstract IAddEditeLoanViewModel LoadViewModel(ModalNavigationStore modalNavigationStore, BooksStore booksStore, ClientsStore clientsStore, LoansStore loansStore, LoanRepository loanRepository, SettingsStore settingsStore, BooksRepository booksRepository, ReservedBooksRepository reservedBooksRepository, ILoan loan = null);
    }
}