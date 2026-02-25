using TestApp.Store;

namespace TestApp.Command.BooksCommands
{
    public class ReloadClientsCommand : CommandBase
    {
        #region Dependencies
        private BooksStore _booksStore;
        #endregion


        #region Contructor
        /// <summary>
        /// 
        /// </summary>
        /// <param name="booksStore"></param>
        public ReloadClientsCommand(BooksStore booksStore)
        {
            _booksStore = booksStore;
        }
        #endregion


        #region Execution

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameter">No Parameter Need</param>
        public override async void Execute(object? parameter)
        {
            await _booksStore.GetAllBooks();
        }
        #endregion
    }
}
