using My_Library.Store;
using My_Library.ViewModel.SettingsViewModel;

namespace My_Library.Command.SettingsCommands
{
    public class NavigateToSettingsCommand : CommandBase, INavigateToSettingsCommand
    {
        #region Dependencies
        private INavigationStore _navigationStore;
        private ISettingsViewModel _settingsViewModel;
        #endregion

        #region Contructor
        /// <summary>
        /// set current view of main navigation to to settings view
        /// </summary>
        private ISettingNavigationStore _settingsNavigationStore = new SettingNavigationStore();
        public NavigateToSettingsCommand(INavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            _settingsViewModel = new SettingsViewModel(_settingsNavigationStore);
        }
        #endregion

        #region Execution
        /// <summary>
        /// </summary>
        /// <param name="parameter">no marametes needed</param>
        public override void Execute(object? parameter)
        {
            _navigationStore.ContentScreen = _settingsViewModel;
        }
        #endregion
    }
}
