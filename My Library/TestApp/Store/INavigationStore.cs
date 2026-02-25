using My_Library.ViewModel;

namespace My_Library.Store
{
    public interface INavigationStore
    {
        IViewModelBase ContentScreen { get; set; }
        INavigationBarViewModel MainContentViewModel { get; set; }
        IStatusBarViewModel StatusBarViewModel { get; set; }

        event Action ContentViewModelChanged;
        event Action MainContentViewModelChanged;
        event Action StatusBarViewModelChanged;
    }
}