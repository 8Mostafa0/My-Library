using TestApp.Store;
using TestApp.ViewModel.LoanViewModels;

namespace TestApp.Command.LoansCommands
{
    public class SortLoansListCommand : CommandBase
    {
        #region Dependencies
        private LoansStore _loansStore;
        private LoansViewModel _loansViewModel;
        #endregion


        #region Contructor
        /// <summary>
        /// sort loans by Sortindex
        /// 0 to not returned loans
        /// 1 to dilayed loan
        /// 3 to returned loan
        /// </summary>
        /// <param name="loansViewModel"></param>
        /// <param name="loansStore"></param>
        public SortLoansListCommand(LoansViewModel loansViewModel, LoansStore loansStore)
        {
            _loansViewModel = loansViewModel;
            _loansStore = loansStore;
        }
        #endregion

        #region Execution
        /// <summary>
        /// </summary>
        /// <param name="parameter">no marametes needed</param>
        public override async void Execute(object? parameter)
        {
            switch (_loansViewModel.SortIndex)
            {
                case 0: { await _loansStore.GetAllLoans("SELECT * FROM Loans WHERE ReturnedDate IS NULL"); break; }
                case 1: { await _loansStore.GetAllLoans("SELECT * FROM Loans WHERE ReturnDate < GETDATE() AND  ReturnedDate IS NULL"); break; }
                case 2: { await _loansStore.GetAllLoans("SELECT * FROM Loans WHERE ReturnedDate IS NOT NULL"); break; }
            }
        }
        #endregion
    }
}
