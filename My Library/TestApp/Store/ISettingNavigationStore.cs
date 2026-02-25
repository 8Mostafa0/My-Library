using My_Library.ViewModel;

namespace My_Library.Store
{
    public interface ISettingNavigationStore
    {
        IViewModelBase CurrentSettingViewModel { get; set; }

        event Action SettingViewModelChanged;

        void OnSettingViewModelChanged();
    }
}