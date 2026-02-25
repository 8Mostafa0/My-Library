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
        ICommand EditeReservBookCommand { get; }
        bool IsModalOpen { get; }
        ICommand LoadReservedBooksCommand { get; }
        ICommand RemoveReservBookCommand { get; }
        IEnumerable<IReservedBookViewModel> ReservedBooks { get; }
        ICommand ResetReservBookCommand { get; }
        ICommand SearchBookNameInReservedBookCommand { get; }
        IReservedBookViewModel SelectedReservedBook { get; set; }

        static abstract IReservedBooksViewModel LoadViewModel(ReservedBooksStore reservedBooksStore, ModalNavigationStore modalNavigationStore, ClientsStore clientsStore, BooksStore booksStore, LoanRepository loansRepository, ClientsRepository clientsRepository, ReservedBooksRepository reservedBooksRepository);
    }
}