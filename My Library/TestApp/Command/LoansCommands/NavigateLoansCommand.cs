using My_Library.Service;
using My_Library.Store;
using My_Library.ViewModel.LoanViewModels;

namespace My_Library.Command.LoansCommands
{
    public class NavigateLoansCommand : CommandBase
    {
        #region Dependencies
        private ILoansViewModel _loansViewModel;
        private NavigationStore _navigationStore;
        #endregion


        #region Contructor
        /// <summary>
        /// set content of navigate to loans view model
        /// </summary>
        /// <param name="navigationStore"></param>
        /// <param name="modalNavigationStore"></param>
        /// <param name="loansStore"></param>
        /// <param name="clientsStore"></param>
        /// <param name="booksStore"></param>
        /// <param name="loanRepository"></param>
        /// <param name="settingsStore"></param>
        /// <param name="booksRepository"></param>
        /// <param name="reservedBooksRepository"></param>
        public NavigateLoansCommand(NavigationStore navigationStore, ModalNavigationStore modalNavigationStore, LoansStore loansStore, ClientsStore clientsStore, BooksStore booksStore, LoanRepository loanRepository, SettingsStore settingsStore, BooksRepository booksRepository, ReservedBooksRepository reservedBooksRepository)
        {
            _navigationStore = navigationStore;
            _loansViewModel = LoansViewModel.LoadViewModel(modalNavigationStore, loansStore, clientsStore, booksStore, loanRepository, settingsStore, booksRepository, reservedBooksRepository);
        }
        #endregion


        #region Execution
        /// <summary>
        /// </summary>
        /// <param name="parameter">no marametes needed</param>
        public override void Execute(object? parameter)
        {
            _navigationStore.ContentScreen = _loansViewModel;
        }
        #endregion
    }
}
