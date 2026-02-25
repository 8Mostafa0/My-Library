using System.Windows.Input;

namespace My_Library.ViewModel
{
    public interface ILoginViewModel
    {
        ICommand CloseAppCommand { get; }
        bool FirstOpen { get; }
        ICommand LoginCommand { get; }
        string Password { get; set; }
        string Title { get; set; }
    }
}