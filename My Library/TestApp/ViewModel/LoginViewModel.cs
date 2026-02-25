using Microsoft.IdentityModel.Tokens;
using My_Library.Command.LoginCommands;
using My_Library.DbContext;
using My_Library.Service;
using My_Library.Store;
using System.Windows.Input;

namespace My_Library.ViewModel
{
    public class LoginViewModel : ViewModelBase, ILoginViewModel
    {
        #region Dependencies
        private string _password;
        public bool FirstOpen { get; }
        public string Title { get; set; }
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnProperychanged(nameof(Password));
            }
        }
        #endregion

        #region Commands
        public ICommand CloseAppCommand { get; }
        public ICommand LoginCommand { get; }

        #endregion

        #region Constructor
        public LoginViewModel(IModalNavigationStore modalNavigationStore, LoanRepository loanRepository, DbContextFactory dbContextFactory, ISettingsStore settingsStore)
        {
            CloseAppCommand = new CloseAppCommand();
            LoginCommand = new LoginCommand(this, modalNavigationStore, loanRepository, dbContextFactory, settingsStore);
            if (settingsStore.GetHashedPassword().IsNullOrEmpty())
            {
                FirstOpen = true;
                Title = "رمزی برای پنل مشخص کنید";
            }
            else
            {
                Title = "رمز عبور خود را وارد کنید";
            }
        }
        #endregion
    }
}
