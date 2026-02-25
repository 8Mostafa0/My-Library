using System.Windows.Input;

namespace My_Library.ViewModel.SettingsViewModel
{
    public interface ISecuritySettingsViewModel : IViewModelBase
    {
        ICommand ChangeLoginPasswordCommand { get; }
        string Password { get; set; }
    }
}