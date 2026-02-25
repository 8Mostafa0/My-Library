using My_Library.Command;
using My_Library.Command.ClientsCommands;
using My_Library.Command.LoansCommands;
using My_Library.Command.ReservCommands;
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
        ICloseModalCommand CloseModalCommand { get; }
        ICommand LoadBooksCommand { get; }
        ILoadClientsCommand LoadClientsCommand { get; }
        ICommand OrderBooksBySubjectCommand { get; }
        ICommand OrderBooksCommand { get; }
        SaveReservationDataCommand SaveReservedBookDataCommand { get; }
        ICommand SearchBookNameCommand { get; }
        ISearchClientNameCommand SearchClientNameCommand { get; }
        IBook SelectedBook { get; set; }
        IClient SelectedClient { get; set; }
        IReservedBook SelectedReservedBook { get; set; }
        string TitleOfLoanScreen { get; set; }

        static abstract IAddEditeReserveBookViewModel LoadViewModel(IModalNavigationStore modalNavigationStore, IReservedBooksStore reservedBooksStore, IClientsStore clientsStore, IBooksStore booksStore, ILoanRepository loanRepository, IReservedBooksRepository reservedBooksRepository, IClientsRepository clientsRepository, IReservedBook reservedBook = null);
    }
}