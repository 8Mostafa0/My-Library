using My_Library.Command.ReservCommands;
using My_Library.Service;
using My_Library.Store;
using My_Library.ViewModel.ModelsViewModel;

namespace My_Library.ViewModel.ReserveBooksViewModels
{
    public interface IReservedBooksViewModel : IViewModelBase
    {
        bool IsModalOpen { get; }
        string BookName { get; set; }
        IAddNewReservBookCommand AddNewReservBookCommand { get; }
        IViewModelBase CurrentModalViewModel { get; }
        IEditeReservBookCommand EditeReservBookCommand { get; }
        ILoadReservedBooksCommand LoadReservedBooksCommand { get; }
        IRemoveReservBookCommand RemoveReservBookCommand { get; }
        IEnumerable<IReservedBookViewModel> ReservedBooks { get; }
        IResetReservBookCommand ResetReservBookCommand { get; }
        ISearchBookNameInReservedBookCommand SearchBookNameInReservedBookCommand { get; }
        IReservedBookViewModel SelectedReservedBook { get; set; }

        static abstract IReservedBooksViewModel LoadViewModel(IReservedBooksStore reservedBooksStore, IModalNavigationStore modalNavigationStore, IClientsStore clientsStore, IBooksStore booksStore, ILoanRepository loansRepository, IClientsRepository clientsRepository, IReservedBooksRepository reservedBooksRepository);
    }
}