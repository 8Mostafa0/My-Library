namespace My_Library.ViewModel
{
    public interface ILayoutViewModel : IViewModelBase
    {
        IViewModelBase contentViewModel { get; }
        INavigationBarViewModel MainContentViewModel { get; }
        IStatusBarViewModel StatusBarViewModel { get; }
    }
}