using TestApp.Model;
using TestApp.Service;
using TestApp.Store;
using TestApp.ViewModel.LoanViewModels;

namespace TestApp.Command.LoansCommands
{
    public class ShowLoanModalCommand : CommandBase
    {
        #region Dependencies
        private ModalNavigationStore _modalNavigationStore;
        private AddEditeLoanViewModel _addEditeLoanViewModel;
        #endregion


        #region Contructor
        /// <summary>
        /// show loan modal by set modal view to the loan modal
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
        public ShowLoanModalCommand(ModalNavigationStore modalNavigationStore, BooksStore booksStore, ClientsStore clientsStore, LoansStore loansStore, LoanRepository loanRepository, SettingsStore settingsStore, BooksRepository booksRepository, ReservedBooksRepository reservedBooksRepository, Loan loan = null)
        {
            _modalNavigationStore = modalNavigationStore;
            _addEditeLoanViewModel = AddEditeLoanViewModel.LoadViewModel(modalNavigationStore, booksStore, clientsStore, loansStore, loanRepository, settingsStore, booksRepository, reservedBooksRepository, loan);
        }
        #endregion


        #region Execution
        /// <summary>
        /// </summary>
        /// <param name="parameter">no marametes needed</param>
        public override void Execute(object? parameter)
        {
            _addEditeLoanViewModel.LoadClientsCommand.Execute(null);
            _modalNavigationStore.CurrentViewModel = _addEditeLoanViewModel;
        }
        #endregion
    }
}
