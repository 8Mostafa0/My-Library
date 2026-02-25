using My_Library.Command.ReservCommands;
using My_Library.Service;
using My_Library.Store;
using My_Library.ViewModel.ModelsViewModel;
using System.Windows.Input;

namespace My_Library.ViewModel.ReserveBooksViewModels
{
    public interface IReservedBooksViewModel : IViewModelBase
    {
        ICommand AddNewReservBookCommand { get; }
        string BookName { get; set; }
        IViewModelBase CurrentModalViewModel { get; }
        EditeReservBookCommand EditeReservBookCommand { get; }
        bool IsModalOpen { get; }
        LoadReservedBooksCommand LoadReservedBooksCommand { get; }
        RemoveReservBookCommand RemoveReservBookCommand { get; }
        IEnumerable<IReservedBookViewModel> ReservedBooks { get; }
        ResetReservBookCommand ResetReservBookCommand { get; }
        SearchBookNameInReservedBookCommand SearchBookNameInReservedBookCommand { get; }
        IReservedBookViewModel SelectedReservedBook { get; set; }

        static abstract IReservedBooksViewModel LoadViewModel(IReservedBooksStore reservedBooksStore, IModalNavigationStore modalNavigationStore, IClientsStore clientsStore, IBooksStore booksStore, ILoanRepository loansRepository, IClientsRepository clientsRepository, IReservedBooksRepository reservedBooksRepository);
    }
}