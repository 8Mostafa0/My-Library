using My_Library.Store;

namespace My_Library.Command.LoansCommands
{
    public class ReloadLoansListCommand : CommandBase
    {
        #region Dependencies
        private ILoansStore _loansStore;
        #endregion


        #region Contructor
        /// <summary>
        ///  reload all loans from database to loans store
        /// </summary>
        /// <param name="loansStore"></param>
        public ReloadLoansListCommand(ILoansStore loansStore)
        {
            _loansStore = loansStore;
        }
        #endregion

        #region Execution

        /// <summary>
        /// </summary>
        /// <param name="parameter">no marametes needed</param>
        public override async void Execute(object? parameter)
        {
            await _loansStore.GetAllLoans();
        }
        #endregion
    }
}
