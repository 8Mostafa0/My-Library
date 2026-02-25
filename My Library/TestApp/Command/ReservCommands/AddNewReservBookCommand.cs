using My_Library.Service;
using My_Library.Store;
using My_Library.ViewModel.ReserveBooksViewModels;

namespace My_Library.Command.ReservCommands
{
    public class AddNewReservBookCommand : CommandBase
    {
        #region Dependencies
        private IBooksStore _booksStore;
        private IClientsStore _clientsStore;
        private IReservedBooksStore _reservedBooksStore;
        private IModalNavigationStore _modalNavigationStore;
        private IReservedBooksRepository _reservedBooksRepository;
        private ILoanRepository _loanRepository;
        private IClientsRepository _clientsRepository;
        #endregion


        #region Contructor
        /// <summary>
        /// load addedite reserved book view model to modal navigation view
        /// </summary>
        /// <param name="reservedBooksViewModel"></param>
        /// <param name="modalNavigationStore"></param>
        /// <param name="reservedBooksStore"></param>
        /// <param name="clientsStore"></param>
        /// <param name="booksStore"></param>
        /// <param name="loanRepository"></param>
        /// <param name="reservedBooksRepository"></param>
        /// <param name="clientsRepository"></param>
        public AddNewReservBookCommand(
            IModalNavigationStore modalNavigationStore,
            IReservedBooksStore reservedBooksStore,
            IClientsStore clientsStore,
            IBooksStore booksStore,
            ILoanRepository loanRepository,
            IReservedBooksRepository reservedBooksRepository,
            IClientsRepository clientsRepository
            )
        {
            _booksStore = booksStore;
            _clientsStore = clientsStore;
            _reservedBooksStore = reservedBooksStore;
            _modalNavigationStore = modalNavigationStore;
            _reservedBooksRepository = reservedBooksRepository;
            _loanRepository = loanRepository;
            _clientsRepository = clientsRepository;
        }
        #endregion


        #region Execution
        /// <summary>
        /// </summary>
        /// <param name="parameter">no marametes needed</param>

        public override void Execute(object? parameter)
        {
            _modalNavigationStore.CurrentViewModel = AddEditeReserveBookViewModel.LoadViewModel(_modalNavigationStore, _reservedBooksStore, _clientsStore, _booksStore, _loanRepository, _reservedBooksRepository, _clientsRepository, null);
        }
        #endregion
    }
}
