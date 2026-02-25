using My_Library.Command;
using My_Library.DbContext;
using My_Library.Service;
using My_Library.Store;

namespace My_Library.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        #region Dependencies
        private readonly LayoutViewModel _layoutViewModel;
        private ModalNavigationStore _modalNavigationStore;
        public ViewModelBase CurrentViewModel => _layoutViewModel;
        public ViewModelBase CurrentModalView => _modalNavigationStore.CurrentViewModel;

        public bool IsModalOpen => _modalNavigationStore.IsModalOpen;
        #endregion
        #region Constructor
        public MainViewModel(LayoutViewModel layoutViewModel)
        {
            _layoutViewModel = layoutViewModel;
            _modalNavigationStore = new ModalNavigationStore();
            _modalNavigationStore.CurrentViewModelChanged += OnModalChanged;
            new LoginModalCommand(_modalNavigationStore, new LoanRepository(), new DbContextFactory(), new SettingsStore()).Execute(null);

        }
        #endregion
        #region Methods

        /// <summary>
        /// get called each tim change value of modal navigation event trigred
        /// </summary>
        private void OnModalChanged()
        {
            OnProperychanged(nameof(CurrentModalView));
            OnProperychanged(nameof(IsModalOpen));
        }

        #endregion
    }
}
