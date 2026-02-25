using My_Library.Command.SettingsCommands;

namespace My_Library.ViewModel.SettingsViewModel
{
    public interface ISettingsViewModel : IViewModelBase
    {
        IViewModelBase CurrentSettingViewModel { get; }
        INavigateLayoutSettingCommand NavigateLayoutSettingCommand { get; }
        INavigateLoanSettingsCommand NavigateLoanSettingsCommand { get; }
        INavigateSecuritySettingsCommand NavigateSecuritySettingsCommand { get; }
    }
}