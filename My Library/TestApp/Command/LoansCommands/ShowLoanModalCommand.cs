using My_Library.Model;
using My_Library.Service;
using My_Library.Store;
using My_Library.ViewModel.LoanViewModels;

namespace My_Library.Command.LoansCommands
{
    public class ShowLoanModalCommand : CommandBase
    {
        #region Dependencies
        private IModalNavigationStore _modalNavigationStore;
        private IAddEditeLoanViewModel _addEditeLoanViewModel;
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
        public ShowLoanModalCommand(IModalNavigationStore modalNavigationStore, IBooksStore booksStore, IClientsStore clientsStore, ILoansStore loansStore, ILoanRepository loanRepository, ISettingsStore settingsStore, BooksRepository booksRepository, IReservedBooksRepository reservedBooksRepository, ILoan loan = null)
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
