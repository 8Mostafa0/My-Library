using System.Windows;
using My_Library.Store;
using My_Library.ViewModel.SettingsViewModel;

namespace My_Library.Command.SettingsCommands
{
    public class ChangeLoginPasswordCommand : CommandBase
    {
        #region Dependencies
        private SettingsStore _settingsStore;
        private SettingNavigationStore _settingNavigationStore;
        private SecuritySettingsViewModel _securitySettingViewModel;
        #endregion

        #region Contructor
        /// <summary>
        /// save validated password to registry
        /// </summary>
        /// <param name="securitySettingsViewModel"></param>
        /// <param name="settingNavigationStore"></param>
        /// <param name="settingsStore"></param>
        public ChangeLoginPasswordCommand(SecuritySettingsViewModel securitySettingsViewModel, SettingNavigationStore settingNavigationStore, SettingsStore settingsStore)
        {
            _settingsStore = settingsStore;
            _settingNavigationStore = settingNavigationStore;
            _securitySettingViewModel = securitySettingsViewModel;
        }
        #endregion

        #region Execution
        /// <summary>
        /// </summary>
        /// <param name="parameter">no marametes needed</param>
        public override void Execute(object? parameter)
        {

            _settingsStore.SaveNoneHashedPassword(_securitySettingViewModel.Password);
            _settingNavigationStore.CurrentSettingViewModel = null;
            MessageBox.Show("رمز عبور با موفقیت تغییر یافت", "رمز عبور");
        }
        #endregion
    }
}
