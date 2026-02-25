using My_Library.Command;
using My_Library.Command.BooksCommands;
using My_Library.Command.ClientsCommands;
using My_Library.Command.LoansCommands;
using My_Library.Command.ReservCommands;
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
        ICloseModalCommand CloseModalCommand { get; }
        IViewModelBase CurrentModelViewModel { get; }
        ICommand LoadBooksCommand { get; }
        ILoadClientsCommand LoadClientsCommand { get; }
        IOrderBooksBySubjectCommand OrderBooksBySubjectCommand { get; }
        DateTime ReturnDate { get; set; }
        ISaveLoanDataCommand SaveLoanDataCommand { get; }
        ISearchBookNameCommand SearchBookNameCommand { get; }
        ISearchClientNameCommand SearchClientNameCommand { get; }
        IBook SelectedBook { get; set; }
        IClient SelectedClient { get; set; }
        ILoan SelectedLoan { get; set; }
        string TitleOfLoanScreen { get; set; }

        static abstract IAddEditeLoanViewModel LoadViewModel(IModalNavigationStore modalNavigationStore, IBooksStore booksStore, IClientsStore clientsStore, ILoansStore loansStore, ILoanRepository loanRepository, ISettingsStore settingsStore, IBooksRepository booksRepository, IReservedBooksRepository reservedBooksRepository, ILoan loan = null);
    }
}