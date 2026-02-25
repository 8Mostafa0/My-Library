using My_Library.Command.LoginCommands;
using System.Windows.Input;

namespace My_Library.ViewModel
{
    public interface ILoginViewModel : IViewModelBase
    {
        CloseAppCommand CloseAppCommand { get; }
        bool FirstOpen { get; }
        ICommand LoginCommand { get; }
        string Password { get; set; }
        string Title { get; set; }
    }
}