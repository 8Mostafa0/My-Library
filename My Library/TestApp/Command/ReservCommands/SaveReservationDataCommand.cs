using System.Windows;
using TestApp.Model;
using TestApp.Service;
using TestApp.Store;
using TestApp.ViewModel.ReserveBooksViewModels;

namespace TestApp.Command.ReservCommands
{
    public class SaveReservationDataCommand : CommandBase
    {
        #region Dependencies
        private LoanRepository _loanRepository;
        private ClientsRepository _clientsRepository;
        private ReservedBooksStore _reservedBookStore;
        private ModalNavigationStore _modalNavigationStore;
        private ReservedBooksRepository _reservedbooksRepository;
        private AddEditeReserveBookViewModel _addediteReserveBookViewModel;
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
            AddEditeReserveBookViewModel addediteReserveBookViewModel,
            ModalNavigationStore modalNavigationStore,
            ReservedBooksStore reservedBooksStore,
            LoanRepository loanRepository,
            ReservedBooksRepository reservedBooksRepository,
            ClientsRepository clientsRepository
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

            if (_addediteReserveBookViewModel.SelectedClient.Tier <= 0)
            {
                MessageBox.Show("فقط کاربران ویژه میتوانند کتاب رزور کنند", "رزرو کتاب");
                return;
            }

            ReservedBook? UserReservs = await _reservedbooksRepository.UserHaveReservedBook(_addediteReserveBookViewModel.SelectedClient.ID);
            if (UserReservs is not null)
            {
                MessageBox.Show("این کاربر کتابی را از قبل رزرو کرده است", "رزرو کتاب");
                return;
            }

            ReservedBook? BookReservs = await _reservedbooksRepository.BookAlreadyRegistred(_addediteReserveBookViewModel.SelectedBook.ID);
            if (BookReservs is not null)
            {

                MessageBox.Show("کاربری این کتاب را از قبل رزور کرده است", "رزرو کتاب");
                return;
            }

            List<Loan> UserDilayedLoans = await _loanRepository.UserHaveDilayedLoan(_addediteReserveBookViewModel.SelectedClient.ID);
            if (UserDilayedLoans is not null && UserDilayedLoans.Count() > 0)
            {
                MessageBox.Show("کاربر امانتی تحویل نداده و با تاخیر دارد", "رزرو کتاب");
                return;
            }


            if (_addediteReserveBookViewModel.SelectedReservedBook == null)
            {

                ReservedBook reservedBook = new ReservedBook()
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

            _modalNavigationStore.Close();
        }
        #endregion
    }
}
