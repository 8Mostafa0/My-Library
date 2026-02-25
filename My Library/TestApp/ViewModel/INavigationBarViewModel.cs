using My_Library.Command;
using My_Library.Command.SettingsCommands;
using System.Windows.Input;

namespace My_Library.ViewModel
{
    public interface INavigationBarViewModel
    {
        ICommand ClientsCreenCommand { get; }
        ICommand CloseAppCommand { get; }
        ICommand DatabaseCommand { get; }
        ICommand NavigateBooksCommand { get; }
        NavigateHomeScreenCommand NavigateHomeCommand { get; }
        ICommand NavigateLoansCommand { get; }
        ICommand NavigateReservedBooksCommand { get; }
        NavigateToSettingsCommand NavigateToSettingsCommand { get; }
        ICommand OpenModalCommand { get; }
        virtual void Dispose() { }
    }

}