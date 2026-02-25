using My_Library.Service;
using My_Library.Store;
using My_Library.ViewModel;
using System.Windows;

namespace My_Library
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        protected override void OnStartup(StartupEventArgs e)
        {
            INavigationStore navigationStore = new NavigationStore();
            IClientsStore clientsStore = new ClientsStore();
            ILoansStore loansStore = new LoansStore();
            IBooksStore booksStore = new BooksStore();
            ISettingsStore settingsStore = new SettingsStore();
            ILoanRepository loanRepository = new LoanRepository();
            IReservedBooksStore reservedBooksStore = new ReservedBooksStore();
            IReservedBooksRepository reservedBooksRepository = new ReservedBooksRepository();
            IBooksRepository booksRepository = new BooksRepository();
            IClientsRepository clientsRepository = new ClientsRepository();
            navigationStore.ContentScreen = new HomeViewModel(clientsStore, booksStore, loansStore);
            navigationStore.StatusBarViewModel = new StatusBarViewModel();

            navigationStore.MainContentViewModel = new NavigationBarViewModel(
                navigationStore,
                reservedBooksStore,
                clientsStore,
                booksStore,
                loansStore,
                loanRepository,
                settingsStore,
                booksRepository,
                reservedBooksRepository,
                clientsRepository
                );

            ILayoutViewModel layoutViewModel = new LayoutViewModel(navigationStore);

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(layoutViewModel)
            };
            MainWindow.Show();

            base.OnStartup(e);
        }
    }

}
