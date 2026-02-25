using My_Library.Service;
using My_Library.Store;
using My_Library.ViewModel;

namespace My_Library.Command.ClientsCommands
{
    public class NavigateClientScreenCommand : CommandBase
    {
        #region Dependencies
        private IClientsStore _clientsStore;
        private INavigationStore _navigationStore;
        private IClientsViewModel _clientsViewModel;
        #endregion

        #region Contructor
        /// <summary>
        /// set content of curent view in content store to clients view model
        /// </summary>
        /// <param name="navigationStore"></param>
        /// <param name="clientsStore"></param>
        /// <param name="loanRepository"></param>
        /// <param name="reservedBooksRepository"></param>
        public NavigateClientScreenCommand(INavigationStore navigationStore, IClientsStore clientsStore, LoanRepository loanRepository, IReservedBooksRepository reservedBooksRepository)
        {
            _navigationStore = navigationStore;
            _clientsStore = clientsStore;
            _clientsViewModel = ClientsViewModel.LoadViewModel(_clientsStore, loanRepository, reservedBooksRepository);
        }
        #endregion


        #region Execution

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameter">no marametes needed</param>
        public override void Execute(object? parameter)
        {
            _navigationStore.ContentScreen = _clientsViewModel;
        }
        #endregion
    }
}
