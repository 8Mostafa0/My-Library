using My_Library.Command.LoginCommands;

namespace My_Library.ViewModel
{
    public interface ILoginViewModel : IViewModelBase
    {
        ICloseAppCommand CloseAppCommand { get; }
        bool FirstOpen { get; }
        ILoginCommand LoginCommand { get; }
        string Password { get; set; }
        string Title { get; set; }
    }
}