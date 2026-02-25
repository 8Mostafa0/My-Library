using Microsoft.IdentityModel.Tokens;
using System.Windows;
using System.Windows.Input;
using My_Library.Command.SettingsCommands;
using My_Library.Store;

namespace My_Library.ViewModel.SettingsViewModel
{
    public class SecuritySettingsViewModel : ViewModelBase
    {
        #region Dependencies
        private string _password;
        public string Password
        {
            get => _password;
            set
            {
                MessageBox.Show((!value.IsNullOrEmpty()).ToString());
                MessageBox.Show(value.Count().ToString());
                if (!value.IsNullOrEmpty() || value.Count() >= 5)
                {
                    _password = value;
                    OnProperychanged(nameof(Password));
                }
                else
                {
                    MessageBox.Show("لطفا رمز عبور را بیشتر از 5 حرف وارد کنید", "رمز عبور");
                }
            }
        }
        private SettingsStore _settingsStore;
        private SettingNavigationStore _settingNavigationStore;
        #endregion

        #region Commands
        public ICommand ChangeLoginPasswordCommand { get; }
        #endregion

        #region Contructor
        public SecuritySettingsViewModel(SettingNavigationStore settingNavigationStore)
        {
            _settingsStore = new SettingsStore();
            _settingNavigationStore = settingNavigationStore;
            ChangeLoginPasswordCommand = new ChangeLoginPasswordCommand(this, _settingNavigationStore, _settingsStore);
        }

        #endregion
    }
}
