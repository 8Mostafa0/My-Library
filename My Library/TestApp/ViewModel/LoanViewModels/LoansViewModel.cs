using My_Library.Command.LoansCommands;
using My_Library.Model;
using My_Library.Service;
using My_Library.Store;
using My_Library.ViewModel.ModelsViewModel;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace My_Library.ViewModel.LoanViewModels
{
    public class LoansViewModel : ViewModelBase, ILoansViewModel
    {
        #region Dependencies
        private ModalNavigationStore _modalNavigationStore;
        private ObservableCollection<ILoanViewModel> _loans;
        private LoansStore _loansStore;
        private ClientsStore _clientsStore;
        private BooksStore _booksStore;
        private LoanRepository _loanRepository;
        private SettingsStore _settingsStore;
        private BooksRepository _booksRepository;
        private ReservedBooksRepository _reservedBooksRepository;
        public IViewModelBase CurrentModalViewModel => _modalNavigationStore.CurrentViewModel;
        public IEnumerable<ILoanViewModel> Loans => _loans;

        private int _sortIndex;
        public int SortIndex
        {
            get => _sortIndex;
            set
            {
                _sortIndex = value;
            }
        }
        private string _bookName;
        public string BookName
        {
            get => _bookName;
            set
            {
                _bookName = value;
                OnProperychanged(nameof(BookName));
            }
        }
        private ILoanViewModel _selectedLoan;
        public ILoanViewModel SelectedLoan
        {
            get => _selectedLoan;
            set
            {
                _selectedLoan = value;
            }
        }
        public bool IsModalOpen => _modalNavigationStore.IsModalOpen;

        #endregion

        #region Commands

        public ICommand ShowAddLoanModalCommand { get; }
        public ICommand ShowEditLoanViewModel { get; }
        public ICommand LoadLoansCommand { get; }
        public ICommand OrderBooksCommand { get; }
        public ICommand SearchBookCommand { get; }
        public ICommand ReturnedLoanCommand { get; }
        public ICommand ReloadLoansListCommand { get; }
        public ICommand SortLoansListCommand { get; }
        #endregion

        #region Constructor
        public LoansViewModel(ModalNavigationStore modalNavigationStore, LoansStore loansStore, ClientsStore clientsStore, BooksStore booksStore, LoanRepository loanRepository, SettingsStore settingsStore, BooksRepository booksRepository, ReservedBooksRepository reservedBooksRepository)
        {
            _loans = [];
            _modalNavigationStore = modalNavigationStore;
            _loansStore = loansStore;
            _clientsStore = clientsStore;
            _booksStore = booksStore;
            _loanRepository = loanRepository;
            _settingsStore = settingsStore;
            _booksRepository = booksRepository;
            _reservedBooksRepository = reservedBooksRepository;
            LoadLoansCommand = new LoadLoansCommand(_loansStore);
            ShowAddLoanModalCommand = new ShowLoanModalCommand(_modalNavigationStore, _booksStore, _clientsStore, _loansStore, _loanRepository, _settingsStore, _booksRepository, _reservedBooksRepository);
            ShowEditLoanViewModel = new ShowEditLoanViewModel(_modalNavigationStore, _loansStore, _booksStore, _clientsStore, this, _loanRepository, _settingsStore, _booksRepository, _reservedBooksRepository);
            SortLoansListCommand = new SortLoansListCommand(this, _loansStore);
            ReturnedLoanCommand = new ReturnedLoanCommand(this, _loansStore);
            ReloadLoansListCommand = new ReloadLoansListCommand(_loansStore);
            SearchBookCommand = new SearchBookCommand(this, _loansStore);
            _loansStore.LoansUpdated += UpdateLoans;
            _loansStore.LoanIsAdded += LoanAdded;
            _loansStore.LoanIsUpdated += LoanIsUpdated;
            _modalNavigationStore.CurrentViewModelChanged += OnModalViewModelChanged;
            SelectedLoan = LoanViewModel.Empty();
        }
        #endregion

        #region Methods

        /// <summary>
        /// calles each time all loans list of loans store get changed
        /// </summary>
        /// <param name="loan"></param>
        private void LoanIsUpdated(ILoan loan)
        {
            var updatedVm = new LoanViewModel(loan, _clientsStore, _booksStore);

            var existing = _loans.FirstOrDefault(l => l.ID == loan.Id);
            if (existing != null)
            {
                int index = _loans.IndexOf(existing);
                _loans[index] = updatedVm;
                MessageBox.Show("امانت با موفقیت ویرایش شد", "ویرایش امانت");
            }
            OnProperychanged(nameof(_loans));
        }

        /// <summary>
        /// cal each time new loan add and add it to the loans list
        /// </summary>
        /// <param name="loan"></param>
        private void LoanAdded(ILoan loan)
        {
            loan.Id = _loans.Any() ? _loans.Last().ID + 1 : 1;
            var vm = new LoanViewModel(loan, _clientsStore, _booksStore);
            _loans.Add(vm);
        }

        /// <summary>
        /// called when modal navigation store view set to a view or get null
        /// </summary>
        private void OnModalViewModelChanged()
        {
            OnProperychanged(nameof(CurrentModalViewModel));
            OnProperychanged(nameof(IsModalOpen));
        }
        /// <summary>
        /// called each time loans list get updated
        /// </summary>
        public void UpdateLoans()
        {
            _loans.Clear();
            foreach (ILoanViewModel loan in _loansStore.Loans)
            {
                _loans.Add(loan);
            }
        }
        /// <summary>
        /// Loader for oans view model
        /// </summary>
        /// <param name="modalNavigationStore"></param>
        /// <param name="loansStore"></param>
        /// <param name="clientsStore"></param>
        /// <param name="booksStore"></param>
        /// <param name="loanRepository"></param>
        /// <param name="settingsStore"></param>
        /// <param name="booksRepository"></param>
        /// <param name="reservedBooksRepository"></param>
        /// <returns></returns>
        public static ILoansViewModel LoadViewModel(ModalNavigationStore modalNavigationStore, LoansStore loansStore, ClientsStore clientsStore, BooksStore booksStore, LoanRepository loanRepository, SettingsStore settingsStore, BooksRepository booksRepository, ReservedBooksRepository reservedBooksRepository)
        {
            ILoansViewModel viewModel = new LoansViewModel(modalNavigationStore, loansStore, clientsStore, booksStore, loanRepository, settingsStore, booksRepository, reservedBooksRepository);
            viewModel.LoadLoansCommand.Execute(null);
            return viewModel;
        }


        #endregion
    }
}
