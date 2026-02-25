using My_Library.Command.SettingsCommands;
using System.Windows.Input;

namespace My_Library.ViewModel.SettingsViewModel
{
    public interface ISettingsViewModel : IViewModelBase
    {
        IViewModelBase CurrentSettingViewModel { get; }
        ICommand NavigateLayoutSettingCommand { get; }
        INavigateLoanSettingsCommand NavigateLoanSettingsCommand { get; }
        INavigateSecuritySettingsCommand NavigateSecuritySettingsCommand { get; }
    }
}