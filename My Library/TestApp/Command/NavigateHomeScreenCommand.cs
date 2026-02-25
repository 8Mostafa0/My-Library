using My_Library.Store;
using My_Library.ViewModel;

namespace My_Library.Command
{
    public class NavigateHomeScreenCommand : CommandBase
    {
        #region Dependencies
        private ILoansStore _loansStore;
        private BooksStore _booksStore;
        private ClientsStore _clientsStore;
        private HomeViewModel _homeViewModel;
        private readonly INavigationStore _navigationStore;
        #endregion

        #region Contructor
        /// <summary>
        /// set current view of main navigation to home view 
        /// </summary>
        /// <param name="navigationStore"></param>
        /// <param name="loansStore"></param>
        /// <param name="clientsStore"></param>
        /// <param name="booksStore"></param>
        public NavigateHomeScreenCommand(INavigationStore navigationStore, ILoansStore loansStore, ClientsStore clientsStore, BooksStore booksStore)
        {
            _navigationStore = navigationStore;
            _clientsStore = clientsStore;
            _booksStore = booksStore;
            _loansStore = loansStore;
        }
        #endregion

        #region Execution
        /// <summary>
        /// </summary>
        /// <param name="parameter">no marametes needed</param>
        public override async void Execute(object? parameter)
        {
            await _clientsStore.Load();
            await _booksStore.Load();
            await _loansStore.Load();
            _navigationStore.ContentScreen = new HomeViewModel(_clientsStore, _booksStore, _loansStore);
        }
        #endregion
    }
}
