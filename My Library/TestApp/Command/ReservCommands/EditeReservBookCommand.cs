using My_Library.Service;
using My_Library.Store;
using My_Library.ViewModel.ReserveBooksViewModels;
using System.Windows;

namespace My_Library.Command.ReservCommands
{
    public class EditeReservBookCommand : CommandBase
    {
        #region Dependencies
        private IBooksStore _booksStore;
        private IClientsStore _clientsStore;
        private LoanRepository _loansRepository;
        private ClientsRepository _clientRepository;
        private IReservedBooksStore _reservedBooksStore;
        private IModalNavigationStore _modalNavigationStore;
        private IReservedBooksViewModel _reservedBooksViewModel;
        private IReservedBooksRepository _reservedBooksRepository;
        #endregion


        #region Contructor
        /// <summary>
        /// validate selected reserv and fill to the add edite view modal
        /// </summary>
        /// <param name="booksStore"></param>
        /// <param name="clientsStore"></param>
        /// <param name="loanRepository"></param>
        /// <param name="clientsRepository"></param>
        /// <param name="reservedBooksStore"></param>
        /// <param name="modalNavigationStore"></param>
        /// <param name="reservedBooksViewModel"></param>
        /// <param name="reservedBooksRepository"></param>
        public EditeReservBookCommand(
            IBooksStore booksStore,
            IClientsStore clientsStore,
            LoanRepository loanRepository,
            ClientsRepository clientsRepository,
            IReservedBooksStore reservedBooksStore,
            IModalNavigationStore modalNavigationStore,
            IReservedBooksViewModel reservedBooksViewModel,
            IReservedBooksRepository reservedBooksRepository
            )
        {
            _booksStore = booksStore;
            _clientsStore = clientsStore;
            _loansRepository = loanRepository;
            _clientRepository = clientsRepository;
            _reservedBooksStore = reservedBooksStore;
            _modalNavigationStore = modalNavigationStore;
            _reservedBooksViewModel = reservedBooksViewModel;
            _reservedBooksRepository = reservedBooksRepository;
        }
        #endregion


        #region Execution
        /// <summary>
        /// </summary>
        /// <param name="parameter">no marametes needed</param>
        public override void Execute(object? parameter)
        {
            if (_reservedBooksViewModel.SelectedReservedBook is null)
            {
                MessageBox.Show("لطفا ابتدا نوبتی را برای ویراش انتخاب کنید", "ویرایش رزرو");
            }
            else
            {
                _modalNavigationStore.CurrentViewModel = AddEditeReserveBookViewModel.LoadViewModel(
                    _modalNavigationStore,
                    _reservedBooksStore,
                    _clientsStore,
                    _booksStore,
                    _loansRepository,
                    _reservedBooksRepository,
                    _clientRepository,
                    _reservedBooksViewModel.SelectedReservedBook?.ToReservedBook()
                    );
            }
        }
        #endregion
    }
}
