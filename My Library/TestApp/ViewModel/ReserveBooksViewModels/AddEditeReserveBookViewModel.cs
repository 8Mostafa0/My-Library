using My_Library.Command;
using My_Library.Command.BooksCommands;
using My_Library.Command.ClientsCommands;
using My_Library.Command.LoansCommands;
using My_Library.Command.ReservCommands;
using My_Library.Model;
using My_Library.Service;
using My_Library.Store;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace My_Library.ViewModel.ReserveBooksViewModels
{
    public class AddEditeReserveBookViewModel : ViewModelBase, IAddEditeReserveBookViewModel
    {
        #region Dependencies
        private IModalNavigationStore _modalNavigationStore;
        private IReservedBooksStore _reservedBooksStore;
        private IClientsStore _clientsStore;
        private IBooksStore _booksStore;
        private IBook _selectedBook;
        private IClient _selectedClient;
        private IReservedBook _selectedReservedBook;
        private string _bookName;
        private string _clientName;
        private int _bookSubject;

        private ObservableCollection<IBook> _books;
        private ObservableCollection<IClient> _clients;

        public IEnumerable<IBook> Books => _books;
        public IEnumerable<IClient> Clients => _clients;

        public string BookName
        {
            get => _bookName;
            set
            {
                _bookName = value;
                _booksStore.SearchBookName = value;
                OnProperychanged(nameof(BookName));
            }
        }

        public string ClientName
        {
            get => _clientName;
            set
            {
                _clientName = value;
                _clientsStore.SearchClientName = value;
                OnProperychanged(nameof(ClientName));
            }
        }

        public IBook SelectedBook
        {
            get => _selectedBook;
            set
            {

                _selectedBook = value;
                OnProperychanged(nameof(SelectedBook));
            }
        }

        public IClient SelectedClient
        {
            get => _selectedClient;
            set
            {
                _selectedClient = value;
                OnProperychanged(nameof(SelectedClient));
            }
        }

        public IReservedBook SelectedReservedBook
        {
            get => _selectedReservedBook;
            set
            {
                _selectedReservedBook = value;
                SetDataOfSelectedReservedBook();
            }
        }
        public int BookSubject
        {
            get => _bookSubject;
            set
            {
                _bookSubject = value;
                _booksStore.SearchSubject = value;
                OnProperychanged(nameof(BookSubject));
            }
        }

        public string TitleOfLoanScreen { get; set; }

        #endregion

        #region Commands

        public ICommand CloseModalCommand { get; }
        public SaveReservationDataCommand SaveReservedBookDataCommand { get; }
        public ICommand SearchBookNameCommand { get; }
        public ICommand SearchClientNameCommand { get; }
        public ICommand LoadClientsCommand { get; }
        public ICommand LoadBooksCommand { get; }
        public ICommand OrderBooksCommand { get; }
        public ICommand OrderBooksBySubjectCommand { get; }


        #endregion

        #region Constructor

        public AddEditeReserveBookViewModel(IModalNavigationStore modalNavigationStore, IReservedBooksStore reservedBooksStore, IClientsStore clientsStore, IBooksStore booksStore, ILoanRepository loanRepository, IReservedBooksRepository reservedBooksRepository, IClientsRepository clientsRepository, IReservedBook reservedBook = null)
        {
            _clients = [];
            _books = [];
            _modalNavigationStore = modalNavigationStore;
            _reservedBooksStore = reservedBooksStore;
            _clientsStore = clientsStore;
            _booksStore = booksStore;
            _booksStore.BooksUpdated += OnBooksUpdated;
            _clientsStore.ClientsUpdated += OnClientsUpdated;
            LoadBooksCommand = new LoadBooksCommand(_booksStore);
            LoadClientsCommand = new LoadClientsCommand(_clientsStore);
            CloseModalCommand = new CloseModalCommand(_modalNavigationStore);
            SearchBookNameCommand = new SearchBookNameCommand(_booksStore);
            SearchClientNameCommand = new SearchClientNameCommand(_clientsStore);
            OrderBooksCommand = new OrderBooksBySubjectCommand(_booksStore);
            SaveReservedBookDataCommand = new SaveReservationDataCommand(this, _modalNavigationStore, _reservedBooksStore, loanRepository, reservedBooksRepository, clientsRepository);
            OrderBooksBySubjectCommand = new OrderBooksBySubjectCommand(_booksStore);
            SelectedReservedBook = reservedBook;
            if (reservedBook != null)
            {
                TitleOfLoanScreen = "ویرایش نوبت رزرو";

            }
            else
            {
                TitleOfLoanScreen = "رزرو نوبت جدید";
            }
        }
        #endregion


        #region Methods

        /// <summary>
        /// get called each time books list of books store get chagned
        /// </summary>
        private void OnBooksUpdated()
        {
            _books.Clear();
            foreach (IBook book in _booksStore.Books)
            {
                _books.Add(book);
            }
        }
        /// <summary>
        /// called each time clients list of clients store get chagned
        /// </summary>
        private void OnClientsUpdated()
        {
            _clients.Clear();
            foreach (IClient client in _clientsStore.Clients)
            {
                _clients.Add(client);
            }
        }
        /// <summary>
        /// fill data for inputed reservedbooks
        /// </summary>
        private void SetDataOfSelectedReservedBook()
        {
            IBook? book = _books.SingleOrDefault(b => b.ID == _selectedReservedBook.BookId);
            _selectedBook = book;
            IClient? client = _clients.SingleOrDefault(c => c.ID == _selectedReservedBook.ClientId);
            _selectedClient = client;
        }
        /// <summary>
        /// Loader for add edite reservedbook view model
        /// </summary>
        /// <param name="modalNavigationStore"></param>
        /// <param name="reservedBooksStore"></param>
        /// <param name="clientsStore"></param>
        /// <param name="booksStore"></param>
        /// <param name="loanRepository"></param>
        /// <param name="reservedBooksRepository"></param>
        /// <param name="clientsRepository"></param>
        /// <param name="reservedBook"></param>
        /// <returns></returns>
        public static IAddEditeReserveBookViewModel LoadViewModel(IModalNavigationStore modalNavigationStore, IReservedBooksStore reservedBooksStore, IClientsStore clientsStore, IBooksStore booksStore, ILoanRepository loanRepository, IReservedBooksRepository reservedBooksRepository, IClientsRepository clientsRepository, IReservedBook reservedBook = null)
        {
            IAddEditeReserveBookViewModel ViewModel = new AddEditeReserveBookViewModel(modalNavigationStore, reservedBooksStore, clientsStore, booksStore, loanRepository, reservedBooksRepository, clientsRepository, reservedBook);
            ViewModel.LoadBooksCommand.Execute(null);
            ViewModel.LoadClientsCommand.Execute(null);
            return ViewModel;
        }
        #endregion

    }
}
