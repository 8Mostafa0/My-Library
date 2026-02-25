using My_Library.Command.SettingsCommands;
using System.Windows.Input;

namespace My_Library.ViewModel.SettingsViewModel
{
    public interface ISecuritySettingsViewModel : IViewModelBase
    {
        ChangeLoginPasswordCommand ChangeLoginPasswordCommand { get; }
        string Password { get; set; }
    }
}