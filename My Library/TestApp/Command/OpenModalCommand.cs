using My_Library.Store;
using My_Library.ViewModel;

namespace My_Library.Command
{
    public class OpenModalCommand : CommandBase
    {
        #region Dependencies
        private Func<IViewModelBase> _createViewModel;
        private IModalNavigationStore _modalNavigationStore;
        #endregion

        #region Contructor
        /// <summary>
        /// set vurrent view of modal navigation to Func of the inputed view model
        /// </summary>
        /// <param name="modalNavigationStore"></param>
        /// <param name="createViewModel"></param>
        public OpenModalCommand(IModalNavigationStore modalNavigationStore, Func<IViewModelBase> createViewModel)
        {
            _modalNavigationStore = modalNavigationStore;
            _createViewModel = createViewModel;
        }
        #endregion

        #region Execution
        /// <summary>
        /// </summary>
        /// <param name="parameter">no marametes needed</param>
        public override void Execute(object? parameter)
        {
            _modalNavigationStore.CurrentViewModel = _createViewModel();
        }
        #endregion
    }
}
