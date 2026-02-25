using My_Library.Service;
using My_Library.Store;
using My_Library.ViewModel.ModelsViewModel;
using System.Windows.Input;

namespace My_Library.ViewModel.LoanViewModels
{
    public interface ILoansViewModel : IViewModelBase
    {
        string BookName { get; set; }
        IViewModelBase CurrentModalViewModel { get; }
        bool IsModalOpen { get; }
        ICommand LoadLoansCommand { get; }
        IEnumerable<ILoanViewModel> Loans { get; }
        ICommand OrderBooksCommand { get; }
        ICommand ReloadLoansListCommand { get; }
        ICommand ReturnedLoanCommand { get; }
        ICommand SearchBookCommand { get; }
        ILoanViewModel SelectedLoan { get; set; }
        ICommand ShowAddLoanModalCommand { get; }
        ICommand ShowEditLoanViewModel { get; }
        int SortIndex { get; set; }
        ICommand SortLoansListCommand { get; }

        static abstract ILoansViewModel LoadViewModel(ModalNavigationStore modalNavigationStore, LoansStore loansStore, ClientsStore clientsStore, BooksStore booksStore, LoanRepository loanRepository, SettingsStore settingsStore, BooksRepository booksRepository, ReservedBooksRepository reservedBooksRepository);
        void UpdateLoans();
    }
}