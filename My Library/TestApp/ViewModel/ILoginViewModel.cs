using System.Windows.Input;

namespace My_Library.ViewModel
{
    public interface ILoginViewModel : IViewModelBase
    {
        ICommand CloseAppCommand { get; }
        bool FirstOpen { get; }
        ICommand LoginCommand { get; }
        string Password { get; set; }
        string Title { get; set; }
    }
}