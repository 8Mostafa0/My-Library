using My_Library.Command.LoginCommands;

namespace My_Library.ViewModel
{
    public interface ILoginViewModel : IViewModelBase
    {
        CloseAppCommand CloseAppCommand { get; }
        bool FirstOpen { get; }
        LoginCommand LoginCommand { get; }
        string Password { get; set; }
        string Title { get; set; }
    }
}