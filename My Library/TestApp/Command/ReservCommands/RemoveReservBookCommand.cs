using My_Library.Store;
using My_Library.ViewModel.ReserveBooksViewModels;
using System.Windows;

namespace My_Library.Command.ReservCommands
{
    public class RemoveReservBookCommand : CommandBase, IRemoveReservBookCommand
    {
        #region Dependencies
        private IReservedBooksStore _reservedBooksStore;
        private IReservedBooksViewModel _reservedBooksViewModel;
        #endregion

        #region Contructor
        /// <summary>
        /// validate selected reserv then ask for delete
        /// </summary>
        /// <param name="reservedBooksViewModel"></param>
        /// <param name="reservedBooksStore"></param>
        public RemoveReservBookCommand(IReservedBooksViewModel reservedBooksViewModel, IReservedBooksStore reservedBooksStore)
        {
            _reservedBooksStore = reservedBooksStore;
            _reservedBooksViewModel = reservedBooksViewModel;
        }
        #endregion

        #region Execution
        /// <summary>
        /// </summary>
        /// <param name="parameter">no marametes needed</param>
        public override async void Execute(object? parameter)
        {
            if (_reservedBooksViewModel.SelectedReservedBook is null)
            {
                MessageBox.Show("لطفا نوبتی را برای حذف انتخاب کنید", "حذف نوبت");
            }
            else
            {

                var AskResult = MessageBox.Show("آیا از حذف این نوبت مطمن هستید؟", "حذف نوبت", MessageBoxButton.YesNo);
                if (AskResult == MessageBoxResult.Yes)
                {
                    await _reservedBooksStore.DeleteReservBook(_reservedBooksViewModel.SelectedReservedBook.ToReservedBook());
                }
            }
        }
        #endregion
    }
}
