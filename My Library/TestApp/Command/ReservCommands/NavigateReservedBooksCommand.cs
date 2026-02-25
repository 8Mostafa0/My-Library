using My_Library.Service;
using My_Library.Store;
using My_Library.ViewModel.ReserveBooksViewModels;

namespace My_Library.Command.ReservCommands
{
    public class NavigateReservedBooksCommand : CommandBase
    {
        #region Dependencies
        private IBooksStore _booksStore;
        private IClientsStore _clientsStore;
        private INavigationStore _navigationStore;
        private IReservedBooksStore _reservedBooksStore;
        private IModalNavigationStore _modalNavigationStore;
        private IReservedBooksViewModel _reservedBooksViewModel;
        #endregion

        #region Contructor
        /// <summary>
        /// 
        /// </summary>
        /// <param name="navigationStore"></param>
        /// <param name="modalNavigationStore"></param>
        /// <param name="reservedBooksStore"></param>
        /// <param name="clientsStore"></param>
        /// <param name="booksStore"></param>
        /// <param name="loansRepository"></param>
        /// <param name="clientsRepository"></param>
        /// <param name="reservedBooksRepository"></param>
        public NavigateReservedBooksCommand(
            INavigationStore navigationStore,
            IModalNavigationStore modalNavigationStore,
            IReservedBooksStore reservedBooksStore,
            IClientsStore clientsStore,
            IBooksStore booksStore,
            ILoanRepository loansRepository,
            IClientsRepository clientsRepository,
            IReservedBooksRepository reservedBooksRepository
            )
        {
            _booksStore = booksStore;
            _clientsStore = clientsStore;
            _navigationStore = navigationStore;
            _reservedBooksStore = reservedBooksStore;
            _modalNavigationStore = modalNavigationStore;

            _reservedBooksViewModel = ReservedBooksViewModel.LoadViewModel(_reservedBooksStore, _modalNavigationStore, _clientsStore, _booksStore, loansRepository, clientsRepository, reservedBooksRepository);
        }
        #endregion

        #region Execution
        /// <summary>
        /// </summary>
        /// <param name="parameter">no marametes needed</param>
        public override void Execute(object? parameter)
        {
            _navigationStore.ContentScreen = _reservedBooksViewModel;
        }
        #endregion
    }
}
