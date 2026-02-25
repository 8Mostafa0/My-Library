using My_Library.Command;
using My_Library.Command.BooksCommands;
using My_Library.Command.ClientsCommands;
using My_Library.Command.LoansCommands;
using My_Library.Command.LoginCommands;
using My_Library.Command.ReservCommands;
using My_Library.Command.SettingsCommands;
using My_Library.Service;
using My_Library.Store;
using System.Windows.Input;

namespace My_Library.ViewModel
{
    public class NavigationBarViewModel : ViewModelBase, INavigationBarViewModel
    {
        #region Dependencies
        private readonly INavigationStore _navigationStore;
        private readonly IModalNavigationStore _modalNavigationStore;
        private IReservedBooksStore _reservedBooksStore;
        private IBooksStore _booksStore;
        private IClientsStore _clientsStore;
        private ILoansStore _loansStore;
        #endregion

        #region Commands
        public ICommand NavigateHomeCommand { get; }
        public ICommand DatabaseCommand { get; }

        public ICommand ClientsCreenCommand { get; }

        public ICommand NavigateBooksCommand { get; }

        public ICommand OpenModalCommand { get; }
        public ICommand NavigateLoansCommand { get; }
        public ICommand NavigateToSettingsCommand { get; }
        public ICommand NavigateReservedBooksCommand { get; }
        public ICommand CloseAppCommand { get; }
        #endregion

        #region Constructr
        public NavigationBarViewModel(
            INavigationStore navigationStore,
            IReservedBooksStore reservedBooksStore,
            IClientsStore clientsStore,
            IBooksStore booksStore,
            ILoansStore loansStore,
            ILoanRepository loanRepository,
            ISettingsStore settingsStore,
            IBooksRepository booksRepository,
            IReservedBooksRepository reservedBooksRepository,
            IClientsRepository clientsRepository
            )
        {
            _navigationStore = navigationStore;
            _reservedBooksStore = reservedBooksStore;
            _clientsStore = clientsStore;
            _booksStore = booksStore;
            _loansStore = loansStore;
            _modalNavigationStore = new ModalNavigationStore();
            NavigateHomeCommand = new NavigateHomeScreenCommand(_navigationStore, _loansStore, _clientsStore, _booksStore);
            NavigateHomeCommand.Execute(null);
            ClientsCreenCommand = new NavigateClientScreenCommand(_navigationStore, _clientsStore, loanRepository, reservedBooksRepository);
            NavigateBooksCommand = new NavigateBooksCommand(_navigationStore, _booksStore, loanRepository, reservedBooksRepository, booksRepository);
            NavigateLoansCommand = new NavigateLoansCommand(_navigationStore, _modalNavigationStore, _loansStore, _clientsStore, _booksStore, loanRepository, settingsStore, booksRepository, reservedBooksRepository);
            NavigateToSettingsCommand = new NavigateToSettingsCommand(_navigationStore);
            NavigateReservedBooksCommand = new NavigateReservedBooksCommand(_navigationStore, _modalNavigationStore, _reservedBooksStore, clientsStore, booksStore, loanRepository, clientsRepository, reservedBooksRepository);
            CloseAppCommand = new CloseAppCommand();
        }
        #endregion
    }
}
