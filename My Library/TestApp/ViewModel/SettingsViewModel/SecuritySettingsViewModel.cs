using Microsoft.IdentityModel.Tokens;
using My_Library.Command.SettingsCommands;
using My_Library.Store;
using System.Windows;
using System.Windows.Input;

namespace My_Library.ViewModel.SettingsViewModel
{
    public class SecuritySettingsViewModel : ViewModelBase, ISecuritySettingsViewModel
    {
        #region Dependencies
        private string _password;
        public string Password
        {
            get => _password;
            set
            {
                if (!value.IsNullOrEmpty() || value.Count() >= 5)
                {
                    _password = value;
                    OnProperychanged(nameof(Password));
                }
                else
                {
                    _password = null;
                    MessageBox.Show("لطفا رمز عبور را بیشتر از 5 حرف وارد کنید", "رمز عبور");
                }
            }
        }
        private ISettingsStore _settingsStore;
        private ISettingNavigationStore _settingNavigationStore;
        #endregion

        #region Commands
        public ICommand ChangeLoginPasswordCommand { get; }
        #endregion

        #region Contructor
        public SecuritySettingsViewModel(ISettingNavigationStore settingNavigationStore)
        {
            _settingsStore = new SettingsStore();
            _settingNavigationStore = settingNavigationStore;
            ChangeLoginPasswordCommand = new ChangeLoginPasswordCommand(this, _settingNavigationStore, _settingsStore);
        }

        #endregion
    }
}
