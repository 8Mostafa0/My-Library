using My_Library.Store;

namespace My_Library.Command.ReservCommands
{
    public class ResetReservBookCommand : CommandBase
    {
        #region Dependencies
        private IReservedBooksStore _reservedBooksStore;
        #endregion


        #region Contructor
        /// <summary>
        /// load all reserved book from database to reserved book store
        /// </summary>
        /// <param name="reservedBooksStore"></param>
        public ResetReservBookCommand(IReservedBooksStore reservedBooksStore)
        {
            _reservedBooksStore = reservedBooksStore;
        }
        #endregion

        #region Execution
        /// <summary>
        /// </summary>
        /// <param name="parameter">no marametes needed</param>
        public override async void Execute(object? parameter)
        {
            await _reservedBooksStore.GetReservedBooksAsync();
        }
        #endregion
    }
}
