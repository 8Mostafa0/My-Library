using My_Library.Command.LoansCommands;
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
        ISearchBookCommand SearchBookCommand { get; }
        ILoanViewModel SelectedLoan { get; set; }
        IShowLoanModalCommand ShowAddLoanModalCommand { get; }
        IShowEditLoanViewModel ShowEditLoanViewModel { get; }
        int SortIndex { get; set; }
        ISortLoansListCommand SortLoansListCommand { get; }

        static abstract ILoansViewModel LoadViewModel(IModalNavigationStore modalNavigationStore, ILoansStore loansStore, IClientsStore clientsStore, IBooksStore booksStore, ILoanRepository loanRepository, ISettingsStore settingsStore, IBooksRepository booksRepository, IReservedBooksRepository reservedBooksRepository);
        void UpdateLoans();
    }
}