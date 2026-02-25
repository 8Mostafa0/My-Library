using System.Windows;
using TestApp.Service;
using TestApp.Store;
using TestApp.ViewModel;

namespace TestApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        protected override void OnStartup(StartupEventArgs e)
        {
            NavigationStore navigationStore = new NavigationStore();
            ClientsStore clientsStore = new ClientsStore();
            LoansStore loansStore = new LoansStore();
            BooksStore booksStore = new BooksStore();
            SettingsStore settingsStore = new SettingsStore();
            LoanRepository loanRepository = new LoanRepository();
            ReservedBooksStore reservedBooksStore = new ReservedBooksStore();
            ReservedBooksRepository reservedBooksRepository = new ReservedBooksRepository();
            BooksRepository booksRepository = new BooksRepository();
            ClientsRepository clientsRepository = new ClientsRepository();
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

            LayoutViewModel layoutViewModel = new LayoutViewModel(navigationStore);

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(layoutViewModel)
            };
            MainWindow.Show();

            base.OnStartup(e);
        }
    }

}
