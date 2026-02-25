using My_Library.Command;
using My_Library.Command.ClientsCommands;
using My_Library.Command.LoansCommands;
using My_Library.Command.LoginCommands;
using My_Library.Command.ReservCommands;
using My_Library.Command.SettingsCommands;
using System.Windows.Input;

namespace My_Library.ViewModel
{
    public interface INavigationBarViewModel
    {
        INavigateClientScreenCommand ClientsCreenCommand { get; }
        CloseAppCommand CloseAppCommand { get; }
        ICommand DatabaseCommand { get; }
        INavigateBooksCommand NavigateBooksCommand { get; }
        INavigateHomeScreenCommand NavigateHomeCommand { get; }
        INavigateLoansCommand NavigateLoansCommand { get; }
        NavigateReservedBooksCommand NavigateReservedBooksCommand { get; }
        INavigateToSettingsCommand NavigateToSettingsCommand { get; }
        ICommand OpenModalCommand { get; }
        virtual void Dispose() { }
    }

}