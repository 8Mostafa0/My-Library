using My_Library.Model;
using My_Library.Service;

namespace My_Library.Store
{
    public class ReservedBooksStore : IReservedBooksStore
    {
        #region Dependencies
        private IReservedBooksRepository _resrvedBooksRepository;
        private List<IReservedBook> _reservedBooks;

        public IEnumerable<IReservedBook> ReservedBook => _reservedBooks;
        public Lazy<Task> _initilizeLazy;
        public event Action ReservedBooksUpdated;
        public event Action<IReservedBook> ReservedBookAdded;
        public event Action<IReservedBook> ReservedBookEdited;
        public event Action<IReservedBook> ReservedBookDeleted;


        #endregion

        #region Contructor
        /// <summary>
        /// 
        /// </summary>
        public ReservedBooksStore()
        {
            _reservedBooks = [];
            _initilizeLazy = new Lazy<Task>(Initilize);
            _resrvedBooksRepository = new ReservedBooksRepository();
        }

        #endregion

        #region Methods
        /// <summary>
        /// load all book for first time to  reservedbooks list
        /// </summary>
        /// <returns></returns>
        public async Task Load()
        {
            await _initilizeLazy.Value;
        }

        /// <summary>
        /// call reservedbook update method of databse and invoke reservedbook update event
        /// </summary>
        /// <param name="reservedBook"></param>
        /// <returns></returns>
        public async Task UpdateReservedBook(IReservedBook reservedBook)
        {
            await _resrvedBooksRepository.EditReservBookToDb(reservedBook);
            ReservedBookEdited?.Invoke(reservedBook);
        }
        /// <summary>
        /// call add new reservedbook method of database and invoe add new reservedbook event
        /// </summary>
        /// <param name="reservedBook"></param>
        /// <returns></returns>
        public async Task AddReservBook(IReservedBook reservedBook)
        {
            await _resrvedBooksRepository.AddNewReservedBookToDb(reservedBook);
            ReservedBookAdded?.Invoke(reservedBook);
        }

        /// <summary>
        /// call delete reservedbook method of database and invoke delete reservedbook evnet
        /// </summary>
        /// <param name="reservedBook"></param>
        /// <returns></returns>
        public async Task DeleteReservBook(IReservedBook reservedBook)
        {
            await _resrvedBooksRepository.DeleteReservedBookWithClientToDb(reservedBook);
            ReservedBookDeleted?.Invoke(reservedBook);
        }

        /// <summary>
        /// clear reservedbook list in store 
        /// </summary>
        public void Clear()
        {
            _reservedBooks.Clear();
        }

        /// <summary>
        /// get all selected reservedbook using sql query from database and store them in the memory
        /// </summary>
        /// <param name="customSql"></param>
        /// <returns></returns>
        public async Task GetReservedBooksAsync(string customSql = "")
        {
            IEnumerable<IReservedBook> reservedBooks = await _resrvedBooksRepository.GetAllReservedBooks(customSql);
            _reservedBooks.Clear();
            _reservedBooks.AddRange(reservedBooks);
            ReservedBooksUpdated?.Invoke();
        }

        /// <summary>
        /// get all reserved books ad save them inside memory for first time and then use memory values for next calls
        /// </summary>
        /// <returns></returns>
        private async Task Initilize()
        {
            IEnumerable<IReservedBook> reservedBooks = await _resrvedBooksRepository.GetAllReservedBooks();
            _reservedBooks.Clear();
            _reservedBooks.AddRange(reservedBooks);
            ReservedBooksUpdated?.Invoke();
        }
        #endregion
    }
}
