using My_Library.Command.SettingsCommands;
using System.Windows.Input;

namespace My_Library.ViewModel.SettingsViewModel
{
    public interface ISettingsViewModel : IViewModelBase
    {
        IViewModelBase CurrentSettingViewModel { get; }
        ICommand NavigateLayoutSettingCommand { get; }
        ICommand NavigateLoanSettingsCommand { get; }
        INavigateSecuritySettingsCommand NavigateSecuritySettingsCommand { get; }
    }
}