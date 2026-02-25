using My_Library.ViewModel;

namespace My_Library.Store
{
    public class SettingNavigationStore
    {
        #region Dependencies
        public event Action SettingViewModelChanged;

        private ViewModelBase _currentSettingViewModel;




        public ViewModelBase CurrentSettingViewModel
        {
            get => _currentSettingViewModel;
            set
            {
                _currentSettingViewModel = value;
                OnSettingViewModelChanged();
            }
        }
        #endregion

        #region Methods
        public void OnSettingViewModelChanged()
        {
            SettingViewModelChanged?.Invoke();
        }
        public SettingNavigationStore() { }
        #endregion
    }
}
