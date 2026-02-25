using My_Library.Store;

namespace My_Library.Command.BooksCommands
{
    public class ReloadBooksCommand : CommandBase, IReloadBooksCommand
    {
        #region Dependencies
        private IBooksStore _booksStore;
        #endregion


        #region Contructor
        /// <summary>
        /// 
        /// </summary>
        /// <param name="booksStore"></param>
        public ReloadBooksCommand(IBooksStore booksStore)
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
