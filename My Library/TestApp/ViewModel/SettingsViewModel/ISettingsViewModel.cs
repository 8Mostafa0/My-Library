using System.Windows.Input;

namespace My_Library.ViewModel.SettingsViewModel
{
    public interface ISettingsViewModel : IViewModelBase
    {
        IViewModelBase CurrentSettingViewModel { get; }
        ICommand NavigateLayoutSettingCommand { get; }
        ICommand NavigateLoanSettingsCommand { get; }
        ICommand NavigateSecuritySettingsCommand { get; }
    }
}