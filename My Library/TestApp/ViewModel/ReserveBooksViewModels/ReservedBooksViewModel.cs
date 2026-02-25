using My_Library.Command.ReservCommands;
using My_Library.Model;
using My_Library.Service;
using My_Library.Store;
using My_Library.ViewModel.ModelsViewModel;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace My_Library.ViewModel.ReserveBooksViewModels
{
    public class ReservedBooksViewModel : ViewModelBase, IReservedBooksViewModel
    {
        #region Dependencies
        private IModalNavigationStore _modalNavigationStore;
        private IBooksStore _booksStore;
        private IClientsStore _clientsStore;
        private IReservedBooksStore _reservedBooksStore;
        private string _bookName;
        private ObservableCollection<IReservedBookViewModel> _reservedBooks;

        public IEnumerable<IReservedBookViewModel> ReservedBooks => _reservedBooks;
        private IReservedBookViewModel _selectedReservBook;

        public IReservedBookViewModel SelectedReservedBook
        {
            get => _selectedReservBook;
            set
            {
                if (value != null)
                {
                    _selectedReservBook = value;
                    OnProperychanged(nameof(SelectedReservedBook));
                }
            }
        }

        public string BookName
        {
            get => _bookName;
            set
            {
                _bookName = value;
                _booksStore.SearchBookName = value;
                OnProperychanged(nameof(_bookName));
            }
        }

        public bool IsModalOpen => _modalNavigationStore.IsModalOpen;

        #endregion

        #region Commands
        public IViewModelBase CurrentModalViewModel => _modalNavigationStore.CurrentViewModel;

        public ICommand AddNewReservBookCommand { get; }
        public ICommand RemoveReservBookCommand { get; }

        public ICommand EditeReservBookCommand { get; }
        public ICommand ResetReservBookCommand { get; }

        public ICommand LoadReservedBooksCommand { get; }

        public ICommand SearchBookNameInReservedBookCommand { get; }
        #endregion

        #region Contructor

        public ReservedBooksViewModel(IReservedBooksStore reservedBooksStore, IModalNavigationStore modalNavigationStore, IClientsStore clientsStore, IBooksStore booksStore, ILoanRepository loansRepository, IClientsRepository clientsRepository, IReservedBooksRepository reservedBooksRepository)
        {
            _reservedBooks = [];
            _modalNavigationStore = modalNavigationStore;
            _clientsStore = clientsStore;
            _booksStore = booksStore;
            _reservedBooksStore = reservedBooksStore;
            _modalNavigationStore.CurrentViewModelChanged += OnModalViewModelChanged;
            _reservedBooksStore.ReservedBooksUpdated += UpdateReservedBooks;
            _reservedBooksStore.ReservedBookEdited += OnReservedBookUpdate;
            _reservedBooksStore.ReservedBookAdded += OnReservedBookAdded;
            _reservedBooksStore.ReservedBookDeleted += OnReservedBookDeleted;
            LoadReservedBooksCommand = new LoadReservedBooksCommand(_reservedBooksStore);
            EditeReservBookCommand = new EditeReservBookCommand(
                _booksStore,
                _clientsStore,
                loansRepository,
                clientsRepository,
                _reservedBooksStore,
                _modalNavigationStore,
                this,
                reservedBooksRepository
                );
            AddNewReservBookCommand = new AddNewReservBookCommand(
                _modalNavigationStore,
                _reservedBooksStore,
                _clientsStore,
                _booksStore,
                loansRepository,
                reservedBooksRepository,
                clientsRepository
                );
            RemoveReservBookCommand = new RemoveReservBookCommand(this, _reservedBooksStore);
            ResetReservBookCommand = new ResetReservBookCommand(_reservedBooksStore);
            SearchBookNameInReservedBookCommand = new SearchBookNameInReservedBookCommand(this, _reservedBooksStore);

        }
        #endregion

        #region Methods
        /// <summary>
        /// get called each time a reserved book event get trigred to change its value in reservedbooks list
        /// </summary>
        /// <param name="book"></param>
        private void OnReservedBookUpdate(IReservedBook book)
        {
            IReservedBookViewModel Reserv = new ReservedBookViewModel(book, _clientsStore, _booksStore);
            int index = _reservedBooks.IndexOf(Reserv);
            _reservedBooks[index] = Reserv;
            MessageBox.Show("رزرو با موفقیت ویرایش شد", "ویرایش رزرو");
        }
        /// <summary>
        /// get call each time a reserved book event triger to remove it from reserved books list
        /// </summary>
        /// <param name="book"></param>
        private void OnReservedBookDeleted(IReservedBook book)
        {
            _reservedBooks.Remove(_selectedReservBook);
            MessageBox.Show("رزرو کتاب با موفقیت حذف شد", "حذف رزرو");
        }
        /// <summary>
        /// called each time reserved book add event get trigred to add it to reserved books list
        /// </summary>
        /// <param name="book"></param>

        private void OnReservedBookAdded(IReservedBook book)
        {
            book.ID = _reservedBooks.Any() ? _reservedBooks.Last().ID + 1 : 1;
            IReservedBookViewModel Reserv = new ReservedBookViewModel(book, _clientsStore, _booksStore);
            _reservedBooks.Add(Reserv);
            MessageBox.Show("کتاب با موفقیت رزرو شد", "رزور کتاب");
        }

        /// <summary>
        /// get updated each time reservedbook list in reservedbooks store get changed
        /// </summary>
        private void UpdateReservedBooks()
        {
            _reservedBooks.Clear();
            foreach (IReservedBook reservedBooks in _reservedBooksStore.ReservedBook)
                _reservedBooks.Add(new ReservedBookViewModel(reservedBooks, _clientsStore, _booksStore));
        }

        /// <summary>
        /// called each time modal navigation view get changed
        /// </summary>
        private void OnModalViewModelChanged()
        {
            OnProperychanged(nameof(CurrentModalViewModel));
            OnProperychanged(nameof(IsModalOpen));
        }

        /// <summary>
        /// Loader method for reservedbooks view model
        /// </summary>
        /// <param name="reservedBooksStore"></param>
        /// <param name="modalNavigationStore"></param>
        /// <param name="clientsStore"></param>
        /// <param name="booksStore"></param>
        /// <param name="loansRepository"></param>
        /// <param name="clientsRepository"></param>
        /// <param name="reservedBooksRepository"></param>
        /// <returns></returns>
        public static IReservedBooksViewModel LoadViewModel(IReservedBooksStore reservedBooksStore, IModalNavigationStore modalNavigationStore, IClientsStore clientsStore, IBooksStore booksStore, ILoanRepository loansRepository, IClientsRepository clientsRepository, IReservedBooksRepository reservedBooksRepository)
        {
            IReservedBooksViewModel ViewModel = new ReservedBooksViewModel(reservedBooksStore, modalNavigationStore, clientsStore, booksStore, loansRepository, clientsRepository, reservedBooksRepository);
            ViewModel.LoadReservedBooksCommand.Execute(null);
            return ViewModel;
        }

        #endregion
    }
}
