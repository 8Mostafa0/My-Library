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
            NavigationStore navigationStore = new();
            ClientsStore clientsStore = new();
            LoansStore loansStore = new();
            BooksStore booksStore = new();
            SettingsStore settingsStore = new();
            LoanRepository loanRepository = new();
            ReservedBooksStore reservedBooksStore = new();
            ReservedBooksRepository reservedBooksRepository = new();
            BooksRepository booksRepository = new();
            ClientsRepository clientsRepository = new();
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
