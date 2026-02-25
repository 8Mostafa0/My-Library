using Microsoft.IdentityModel.Tokens;
using My_Library.Store;
using My_Library.ViewModel.SettingsViewModel;
using System.Windows;

namespace My_Library.Command.SettingsCommands
{
    public class ChangeLoginPasswordCommand : CommandBase
    {
        #region Dependencies
        private ISettingsStore _settingsStore;
        private ISettingNavigationStore _settingNavigationStore;
        private ISecuritySettingsViewModel _securitySettingViewModel;
        #endregion

        #region Contructor
        /// <summary>
        /// save validated password to registry
        /// </summary>
        /// <param name="securitySettingsViewModel"></param>
        /// <param name="settingNavigationStore"></param>
        /// <param name="settingsStore"></param>
        public ChangeLoginPasswordCommand(ISecuritySettingsViewModel securitySettingsViewModel, ISettingNavigationStore settingNavigationStore, ISettingsStore settingsStore)
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
            if (_securitySettingViewModel.Password.IsNullOrEmpty() || _securitySettingViewModel.Password.Count() < 5)
            {
                MessageBox.Show("لطفا رمز عبور را بیشتر از 5 حرف وارد کنید", "رمز عبور");
                return;
            }
            _settingsStore.SaveNoneHashedPassword(_securitySettingViewModel.Password);
            _settingNavigationStore.CurrentSettingViewModel = null;
            MessageBox.Show("رمز عبور با موفقیت تغییر یافت", "رمز عبور");
        }
        #endregion
    }
}
