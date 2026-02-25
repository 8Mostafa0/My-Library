using My_Library.ViewModel;

namespace My_Library.Store
{
    public class ModalNavigationStore
    {
        #region Dependencies
        private IViewModelBase _currentViewModel;
        public bool IsModalOpen => CurrentViewModel != null;
        public event Action CurrentViewModelChanged;
        public IViewModelBase CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel?.Dispose();
                _currentViewModel = value;
                OnCurrentViewModelChange();
            }
        }


        #endregion




        #region Methods 

        public void Close()
        {
            CurrentViewModel = null;
            OnCurrentViewModelChange();
        }

        private void OnCurrentViewModelChange()
        {
            CurrentViewModelChanged?.Invoke();

        }
        #endregion
    }
}
