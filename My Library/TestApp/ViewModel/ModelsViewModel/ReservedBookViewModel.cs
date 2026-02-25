using My_Library.Model;
using My_Library.Store;

namespace My_Library.ViewModel.ModelsViewModel
{
    public class ReservedBookViewModel : ViewModelBase, IReservedBookViewModel
    {
        #region Properties
        private ClientsStore _clientsStore;
        private BooksStore _booksStore;
        private IReservedBook _reservedBook;
        public int ID => _reservedBook.ID;
        public int BookId => _reservedBook.BookId;
        public string BookName { get; set; }
        public int ClientId => _reservedBook.ClientId;
        public string ClientName { get; set; }
        public DateTime CreatedAt => _reservedBook.CreatedAt;
        public DateTime UpdatedAt => _reservedBook.UpdatedAt;
        #endregion

        #region Constructor
        public ReservedBookViewModel(IReservedBook reservedBook, ClientsStore clientsStore, BooksStore booksStore)
        {
            _reservedBook = reservedBook ?? throw new ArgumentNullException(nameof(reservedBook));
            _clientsStore = clientsStore ?? throw new ArgumentNullException(nameof(clientsStore));
            _booksStore = booksStore ?? throw new ArgumentNullException(nameof(booksStore));

            var client = clientsStore.Clients.FirstOrDefault(c => c.ID == reservedBook.ClientId);
            ClientName = client != null
                ? $"{client.FirstName} {client.LastName}".Trim()
                : $"Client #{reservedBook.ClientId} (not found)";

            var book = booksStore.Books.FirstOrDefault(b => b.ID == reservedBook.BookId);
            BookName = book?.Name ?? $"Book #{reservedBook.BookId} (not found)";
        }
        #endregion

        #region Methods

        public IReservedBook ToReservedBook()
        {
            return _reservedBook;
        }
        #endregion
    }
}
