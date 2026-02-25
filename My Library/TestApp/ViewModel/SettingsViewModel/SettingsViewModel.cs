using My_Library.Command.SettingsCommands;
using My_Library.Store;
using System.Windows.Input;

namespace My_Library.ViewModel.SettingsViewModel
{
    public class SettingsViewModel : ViewModelBase, ISettingsViewModel
    {
        #region Dependencies
        private ISettingNavigationStore _settingNavigationStore;

        public IViewModelBase CurrentSettingViewModel => _settingNavigationStore.CurrentSettingViewModel;

        #endregion

        #region Commands
        public ICommand NavigateLayoutSettingCommand { get; }
        public ICommand NavigateLoanSettingsCommand { get; }
        public INavigateSecuritySettingsCommand NavigateSecuritySettingsCommand { get; }
        #endregion

        #region Contructor
        public SettingsViewModel(ISettingNavigationStore settingNavigationStore)
        {
            _settingNavigationStore = settingNavigationStore;
            _settingNavigationStore.SettingViewModelChanged += OnSettingViewModelChanged;
            NavigateLayoutSettingCommand = new NavigateLayoutSettingCommand(_settingNavigationStore);
            NavigateLoanSettingsCommand = new NavigateLoanSettingsCommand(_settingNavigationStore);
            NavigateSecuritySettingsCommand = new NavigateSecuritySettingsCommand(_settingNavigationStore);
        }

        #endregion

        #region Methods
        private void OnSettingViewModelChanged()
        {
            OnProperychanged(nameof(CurrentSettingViewModel));
        }
        #endregion

    }
}
