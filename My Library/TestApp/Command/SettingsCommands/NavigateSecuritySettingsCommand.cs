using My_Library.Store;
using My_Library.ViewModel.SettingsViewModel;

namespace My_Library.Command.SettingsCommands
{
    public class NavigateSecuritySettingsCommand : CommandBase, INavigateSecuritySettingsCommand
    {
        #region Dependencies
        private ISettingNavigationStore _settingNavigationStore;
        private ISecuritySettingsViewModel _securitySettingsViewModel;
        #endregion

        #region Contructor
        /// <summary>
        /// set current view of setting navigation to security (change password view) view
        /// </summary>
        /// <param name="settingNavigationStore"></param>
        public NavigateSecuritySettingsCommand(ISettingNavigationStore settingNavigationStore)
        {
            _settingNavigationStore = settingNavigationStore;
            _securitySettingsViewModel = new SecuritySettingsViewModel(_settingNavigationStore);
        }
        #endregion

        #region Execution
        /// <summary>
        /// </summary>
        /// <param name="parameter">no marametes needed</param>
        public override void Execute(object? parameter)
        {
            _settingNavigationStore.CurrentSettingViewModel = _securitySettingsViewModel;
        }
        #endregion
    }
}
