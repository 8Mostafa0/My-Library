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

namespace My_Library.ViewModel.LoanViewModels
{
    public class AddEditeLoanViewModel : ViewModelBase, IAddEditeLoanViewModel
    {

        #region Dependencies
        private ILoan _selectedLoan;
        private IClientsStore _clientsStore;
        private IBooksStore _booksStore;
        private ObservableCollection<IBook> _books;
        private ObservableCollection<IClient> _clients;
        private IClient _seletedClient;
        private IBook _selectedBook;
        private ILoansStore _loansStore;
        private ILoanRepository _loanRepository;
        private IModalNavigationStore _modalNavigationStore;
        private ISettingsStore _settingsStore;
        private IBooksRepository _booksRepository;
        private IReservedBooksRepository _reservedBooksRepository;
        private string _titleOfLoanScreen;

        public ILoan SelectedLoan
        {
            get => _selectedLoan;
            set
            {
                _selectedLoan = value;
                SetDataOfSelectedReservedBook();
            }
        }
        public string TitleOfLoanScreen
        {
            get => _titleOfLoanScreen; set
            {
                _titleOfLoanScreen = value;
                OnProperychanged(nameof(TitleOfLoanScreen));
            }
        }
        public IEnumerable<IBook> Books => _books;
        public IEnumerable<IClient> Clients => _clients;
        public IClient SelectedClient
        {
            get => _seletedClient;
            set
            {
                _seletedClient = value;
                OnProperychanged(nameof(SelectedClient));
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


        private string _bookSearch;
        public string BookSearch
        {
            get => _bookSearch;
            set
            {
                _bookSearch = value;
                _booksStore.SearchBookName = value;
                OnProperychanged(nameof(BookSearch));
            }
        }

        private int _booksSortOrder;
        public int BooksSortOrder
        {
            get => _booksSortOrder;
            set
            {
                _booksSortOrder = value;
                _booksStore.SearchSubject = value;
                OnProperychanged(nameof(_booksSortOrder));
            }
        }

        private string _clientSearch;
        public string ClientSearch
        {
            get => _clientSearch;
            set
            {
                _clientSearch = value;
                _clientsStore.SearchClientName = value;
                OnProperychanged(nameof(ClientSearch));
            }
        }

        private DateTime _returnDate;
        public DateTime ReturnDate
        {
            get => _returnDate;
            set
            {
                _returnDate = value;
                OnProperychanged(nameof(ReturnDate));
            }
        }
        #endregion


        #region Commands

        public IViewModelBase CurrentModelViewModel => _modalNavigationStore.CurrentViewModel;
        public ICommand LoadBooksCommand { get; }
        public ICommand LoadClientsCommand { get; }
        public ICloseModalCommand CloseModalCommand { get; }
        public ISaveLoanDataCommand SaveLoanDataCommand { get; }
        public ICommand SearchBookNameCommand { get; }
        public ICommand OrderBooksBySubjectCommand { get; }
        public ICommand SearchClientNameCommand { get; }
        #endregion

        #region Contructor
        public AddEditeLoanViewModel(IModalNavigationStore modalNavigationStore, IClientsStore clientsStore, IBooksStore booksStore, ILoansStore loanStore, ILoanRepository loanRepository, ISettingsStore settingsStore, IBooksRepository booksRepository, IReservedBooksRepository reservedBooksRepository, ILoan loan = null)
        {
            _clients = [];
            _books = [];
            _clientsStore = clientsStore;
            _clientsStore.ClientsUpdated += OnClientsUpdated;
            _booksStore = booksStore;
            _booksStore.BooksUpdated += OnBooksUpdated;
            _loansStore = loanStore;
            _modalNavigationStore = modalNavigationStore;
            _loanRepository = loanRepository;
            _settingsStore = settingsStore;
            _booksRepository = booksRepository;
            _reservedBooksRepository = reservedBooksRepository;
            LoadBooksCommand = new LoadBooksCommand(booksStore);
            LoadClientsCommand = new LoadClientsCommand(clientsStore);
            SaveLoanDataCommand = new SaveLoanDataCommand(this, _loansStore, _modalNavigationStore, _loanRepository, _settingsStore, _booksRepository, _reservedBooksRepository);
            CloseModalCommand = new CloseModalCommand(_modalNavigationStore);
            SearchBookNameCommand = new SearchBookNameCommand(_booksStore);
            OrderBooksBySubjectCommand = new OrderBooksBySubjectCommand(_booksStore);
            SearchClientNameCommand = new SearchClientNameCommand(_clientsStore);
            _modalNavigationStore.CurrentViewModelChanged += ModalViewModelChange;
            SelectedLoan = loan;
            if (loan is null)
            {
                TitleOfLoanScreen = "امانت جدید";
                ReturnDate = DateTime.Now;
            }
            else
            {
                TitleOfLoanScreen = "ویرایش امانت";
                ReturnDate = loan.ReturnDate;
            }
        }

        #endregion

        #region Methods
        /// <summary>
        /// called after a book been updated
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
        /// update each time store clients list get changed
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
        /// fill data of selected loans to Book and Client
        /// </summary>
        private void SetDataOfSelectedReservedBook()
        {
            if (_selectedLoan is not null)
            {

                IBook? book = _books.SingleOrDefault(b => b.ID == _selectedLoan.BookId);
                SelectedBook = book;
                IClient? client = _clients.SingleOrDefault(c => c.ID == _selectedLoan.ClientId);
                SelectedClient = client;
            }
        }

        /// <summary>
        /// show modal of add edit loan
        /// </summary>
        private void ModalViewModelChange()
        {
            OnProperychanged(nameof(CurrentModelViewModel));
        }
        /// <summary>
        /// loader for addedite view model
        /// </summary>
        /// <param name="modalNavigationStore"></param>
        /// <param name="booksStore"></param>
        /// <param name="clientsStore"></param>
        /// <param name="loansStore"></param>
        /// <param name="loanRepository"></param>
        /// <param name="settingsStore"></param>
        /// <param name="booksRepository"></param>
        /// <param name="reservedBooksRepository"></param>
        /// <param name="loan"></param>
        /// <returns></returns>
        public static IAddEditeLoanViewModel LoadViewModel(IModalNavigationStore modalNavigationStore, IBooksStore booksStore, IClientsStore clientsStore, ILoansStore loansStore, ILoanRepository loanRepository, ISettingsStore settingsStore, IBooksRepository booksRepository, IReservedBooksRepository reservedBooksRepository, ILoan loan = null)
        {
            IAddEditeLoanViewModel ViewModel = new AddEditeLoanViewModel(modalNavigationStore, clientsStore, booksStore, loansStore, loanRepository, settingsStore, booksRepository, reservedBooksRepository, loan);
            ViewModel.LoadBooksCommand.Execute(null);
            ViewModel.LoadClientsCommand.Execute(null);
            ViewModel.SelectedLoan = loan;
            return ViewModel;

        }
        #endregion
    }
}
