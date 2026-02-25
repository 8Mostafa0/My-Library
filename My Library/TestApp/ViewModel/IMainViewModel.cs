namespace My_Library.ViewModel
{
    public interface IMainViewModel
    {
        IViewModelBase CurrentModalView { get; }
        IViewModelBase CurrentViewModel { get; }
        bool IsModalOpen { get; }
    }
}