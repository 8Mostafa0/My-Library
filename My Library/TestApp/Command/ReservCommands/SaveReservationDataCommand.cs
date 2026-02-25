using My_Library.Model;
using My_Library.Service;
using My_Library.Store;
using My_Library.ViewModel.ReserveBooksViewModels;
using System.Windows;

namespace My_Library.Command.ReservCommands
{
    public class SaveReservationDataCommand : CommandBase
    {
        #region Dependencies
        private ILoanRepository _loanRepository;
        private IClientsRepository _clientsRepository;
        private IReservedBooksStore _reservedBookStore;
        private IModalNavigationStore _modalNavigationStore;
        private IReservedBooksRepository _reservedbooksRepository;
        private IAddEditeReserveBookViewModel _addediteReserveBookViewModel;
        #endregion


        #region Contructor
        /// <summary>
        /// validate reserve data
        /// </summary>
        /// <param name="addediteReserveBookViewModel"></param>
        /// <param name="modalNavigationStore"></param>
        /// <param name="reservedBooksStore"></param>
        /// <param name="loanRepository"></param>
        /// <param name="reservedBooksRepository"></param>
        /// <param name="clientsRepository"></param>
        public SaveReservationDataCommand(
            IAddEditeReserveBookViewModel addediteReserveBookViewModel,
            IModalNavigationStore modalNavigationStore,
            IReservedBooksStore reservedBooksStore,
            ILoanRepository loanRepository,
            IReservedBooksRepository reservedBooksRepository,
            IClientsRepository clientsRepository
            )
        {
            _loanRepository = loanRepository;
            _clientsRepository = clientsRepository;
            _reservedBookStore = reservedBooksStore;
            _modalNavigationStore = modalNavigationStore;
            _reservedbooksRepository = reservedBooksRepository;
            _addediteReserveBookViewModel = addediteReserveBookViewModel;
        }
        #endregion

        #region Execution
        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameter">no marametes needed</param>
        public override async void Execute(object? parameter)
        {
            #region Input Validation
            if (_addediteReserveBookViewModel.SelectedClient == null)
            {
                MessageBox.Show("لطفا کاربری را انتخاب کنید", "رزرو کتاب");
                return;
            }
            if (_addediteReserveBookViewModel.SelectedBook == null)
            {
                MessageBox.Show("لطفا کتابی را انتخاب کنید", "رزرو کتاب");
                return;
            }
            #endregion

            #region Client Validation

            if (_addediteReserveBookViewModel.SelectedClient.ID != _addediteReserveBookViewModel.SelectedReservedBook.ClientId)
            {

                if (_addediteReserveBookViewModel.SelectedClient.Tier < _addediteReserveBookViewModel.SelectedBook.Tier)
                {
                    MessageBox.Show("فقط کاربران ویژه میتوانند کتاب رزور کنند", "رزرو کتاب");
                    return;
                }
                List<Loan> UserDilayedLoans = await _loanRepository.UserHaveDilayedLoan(_addediteReserveBookViewModel.SelectedClient.ID);
                if (UserDilayedLoans is not null && UserDilayedLoans.Count() > 0)
                {
                    MessageBox.Show("کاربر امانتی تحویل نداده و با تاخیر دارد", "رزرو کتاب");
                    return;
                }
            }
            #endregion

            #region Book Validation
            if (_addediteReserveBookViewModel.SelectedBook.ID != _addediteReserveBookViewModel.SelectedReservedBook.BookId)
            {

                IReservedBook? UserReservs = await _reservedbooksRepository.UserHaveReservedBook(_addediteReserveBookViewModel.SelectedClient.ID);
                if (UserReservs is not null)
                {
                    MessageBox.Show("این کاربر کتابی را از قبل رزرو کرده است", "رزرو کتاب");
                    return;
                }
                IReservedBook? BookReservs = await _reservedbooksRepository.BookAlreadyRegistred(_addediteReserveBookViewModel.SelectedBook.ID);
                if (BookReservs is not null)
                {

                    MessageBox.Show("کاربری این کتاب را از قبل رزور کرده است", "رزرو کتاب");
                    return;
                }

            }
            #endregion

            #region Edit ReservedBook
            if (_addediteReserveBookViewModel.SelectedReservedBook == null)
            {

                IReservedBook reservedBook = new ReservedBook()
                {
                    BookId = _addediteReserveBookViewModel.SelectedBook.ID,
                    ClientId = _addediteReserveBookViewModel.SelectedClient.ID
                };

                await _reservedBookStore.AddReservBook(reservedBook);
            }
            else
            {
                _addediteReserveBookViewModel.SelectedReservedBook.BookId = _addediteReserveBookViewModel.SelectedBook.ID;
                _addediteReserveBookViewModel.SelectedReservedBook.ClientId = _addediteReserveBookViewModel.SelectedClient.ID;
                await _reservedBookStore.UpdateReservedBook(_addediteReserveBookViewModel.SelectedReservedBook);
            }
            #endregion

            _modalNavigationStore.Close();
        }
        #endregion
    }
}
