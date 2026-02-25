using System.Windows.Input;

namespace My_Library.ViewModel
{
    public interface INavigationBarViewModel
    {
        ICommand ClientsCreenCommand { get; }
        ICommand CloseAppCommand { get; }
        ICommand DatabaseCommand { get; }
        ICommand NavigateBooksCommand { get; }
        ICommand NavigateHomeCommand { get; }
        ICommand NavigateLoansCommand { get; }
        ICommand NavigateReservedBooksCommand { get; }
        ICommand NavigateToSettingsCommand { get; }
        ICommand OpenModalCommand { get; }
        virtual void Dispose() { }
    }

}