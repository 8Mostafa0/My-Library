using My_Library.DbContext;
using My_Library.Service;

namespace My_Library.Command
{
    public class CheckDatabaseCommand : CommandBase
    {
        #region Dependencies
        private ILoanRepository _loansRepository;
        private DbContextFactory _dbContextFactory;
        #endregion

        #region Contructor
        /// <summary>
        /// check ans validate database and tables
        /// </summary>
        public CheckDatabaseCommand(ILoanRepository loanRepository, DbContextFactory dbContextFactory)
        {
            _loansRepository = loanRepository;
            _dbContextFactory = dbContextFactory;
        }
        #endregion

        #region Execution
        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameter"></param>
        public override async void Execute(object? parameter)
        {
            await _dbContextFactory.CheckDatabaseExistsAsync();
        }
        #endregion
    }
}
