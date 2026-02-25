using Microsoft.IdentityModel.Tokens;
using My_Library.Command.LoginCommands;
using My_Library.DbContext;
using My_Library.Service;
using My_Library.Store;

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
        public CloseAppCommand CloseAppCommand { get; }
        public LoginCommand LoginCommand { get; }

        #endregion

        #region Constructor
        public LoginViewModel(IModalNavigationStore modalNavigationStore, ILoanRepository loanRepository, IDbContextFactory dbContextFactory, ISettingsStore settingsStore)
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
