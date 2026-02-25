using My_Library.Model;
using My_Library.Service;
using My_Library.Store;
using My_Library.ViewModel;
using System.Windows;

namespace My_Library.Command.ClientsCommands
{
    public class DeleteClientCommand : CommandBase, IDeleteClientCommand
    {
        #region Dependencies
        private ILoanRepository _loanRepository;
        private readonly IClientsStore _clientsStore;
        private readonly IClientsViewModel _clientsViewModel;
        private IReservedBooksRepository _reservedBooksRepository;
        #endregion


        #region Constructor
        /// <summary>
        /// Check For Selected Client And If Clients Not Have Not Returned Loan Then :
        /// 1_ Remove All Reservations of Client
        /// 2_ Remove All Saved Loans Of Client
        /// 3_ Delete Client Using Clients Store
        /// </summary>
        /// <param name="clientsViewModel"></param>
        /// <param name="clientsStore"></param>
        /// <param name="loanRepository"></param>
        /// <param name="reservedBooksRepository"></param>
        public DeleteClientCommand(IClientsViewModel clientsViewModel, IClientsStore clientsStore, ILoanRepository loanRepository, IReservedBooksRepository reservedBooksRepository)
        {
            _clientsViewModel = clientsViewModel;
            _clientsStore = clientsStore;
            _loanRepository = loanRepository;
            _reservedBooksRepository = reservedBooksRepository;
        }
        #endregion


        #region Execution

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameter"></param>
        public override async void Execute(object? parameter)
        {
            if (_clientsViewModel.SelectedClient is null)
            {
                MessageBox.Show("لطفا ابتدا کاربری را برای حذف انتخاب کنید", "حذف کاربر");
                return;
            }
            List<Loan> UserLoans = await _loanRepository.GetAllClientLoans(_clientsViewModel.SelectedClient.ID);
            if (UserLoans.Count > 0)
            {
                MessageBox.Show("این کاربر امانتی تحویل نشده دارد", "حذف کاربر");
                return;
            }
            else
            {
                MessageBoxResult AskToDelete = MessageBox.Show("کاربر حذف شود؟", "حذف کاربر", MessageBoxButton.YesNo);
                if (AskToDelete == MessageBoxResult.Yes)
                {
                    await _reservedBooksRepository.RemoveClientReservedBooks(_clientsViewModel.SelectedClient.ID);
                    await _loanRepository.RemoveClientLoans(_clientsViewModel.SelectedClient.ID);
                    await _clientsStore.DeleteClient(_clientsViewModel.SelectedClient);
                }
            }
        }
        #endregion
    }
}
