using My_Library.Model;
using My_Library.Service;
using My_Library.Store;
using System.Windows.Input;

namespace My_Library.ViewModel.ReserveBooksViewModels
{
    public interface IAddEditeReserveBookViewModel : IViewModelBase
    {
        string BookName { get; set; }
        IEnumerable<IBook> Books { get; }
        int BookSubject { get; set; }
        string ClientName { get; set; }
        IEnumerable<IClient> Clients { get; }
        ICommand CloseModalCommand { get; }
        ICommand LoadBooksCommand { get; }
        ICommand LoadClientsCommand { get; }
        ICommand OrderBooksBySubjectCommand { get; }
        ICommand OrderBooksCommand { get; }
        ICommand SaveReservedBookDataCommand { get; }
        ICommand SearchBookNameCommand { get; }
        ICommand SearchClientNameCommand { get; }
        IBook SelectedBook { get; set; }
        IClient SelectedClient { get; set; }
        IReservedBook SelectedReservedBook { get; set; }
        string TitleOfLoanScreen { get; set; }

        static abstract IAddEditeReserveBookViewModel LoadViewModel(IModalNavigationStore modalNavigationStore, IReservedBooksStore reservedBooksStore, IClientsStore clientsStore, IBooksStore booksStore, LoanRepository loanRepository, ReservedBooksRepository reservedBooksRepository, ClientsRepository clientsRepository, IReservedBook reservedBook = null);
    }
}