using My_Library.ViewModel;

namespace My_Library.Store
{
    public interface IModalNavigationStore
    {
        IViewModelBase CurrentViewModel { get; set; }
        bool IsModalOpen { get; }

        event Action CurrentViewModelChanged;

        void Close();
    }
}