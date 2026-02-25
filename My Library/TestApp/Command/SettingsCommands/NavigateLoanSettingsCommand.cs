using My_Library.Store;
using My_Library.ViewModel.SettingsViewModel;

namespace My_Library.Command.SettingsCommands
{
    public class NavigateLoanSettingsCommand : CommandBase
    {
        #region Dependencies
        private ISettingNavigationStore _navigationStore;
        private ILoanSettingsViewModel _loanSettingsViewModel = new LoanSettingsViewModel();
        #endregion

        #region Contructor
        /// <summary>
        /// set current view model of setting navigation to loan loan settings
        /// </summary>
        /// <param name="navigationStore"></param>
        public NavigateLoanSettingsCommand(ISettingNavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
        }
        #endregion

        #region Execution
        public override void Execute(object? parameter)
        {
            _navigationStore.CurrentSettingViewModel = _loanSettingsViewModel;
        }
        #endregion
    }
}
