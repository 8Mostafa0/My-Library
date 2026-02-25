using My_Library.Store;
using System.Windows;

namespace My_Library.Command.ReservCommands
{
    public class OrderBooksBySubjectCommand : CommandBase
    {
        #region Dependencies
        private IBooksStore _booksStore;
        #endregion

        #region Contructor
        /// <summary>
        /// Order Book By Entered Subject
        /// </summary>
        /// <param name="booksStore"></param>
        public OrderBooksBySubjectCommand(IBooksStore booksStore)
        {
            _booksStore = booksStore;
        }
        #endregion

        #region Execution
        /// <summary>
        /// Order Book By Entered Subject
        /// </summary>
        /// <param name="parameter"></param>
        public override async void Execute(object? parameter)
        {
            if (_booksStore.SearchSubject < 0)
            {
                MessageBox.Show("لطفا ابتدا یک مورد برای ترتیب بندی انتخاب کنید", "ترتیب بندی");
            }
            string SubjectName = "";
            switch (_booksStore.SearchSubject)
            {
                case 0: { SubjectName = "رمان"; break; }
                case 1: { SubjectName = "قصه"; break; }
                case 2: { SubjectName = "آموزشی"; break; }
                case 3: { SubjectName = "معمایی"; break; }
                case 4: { SubjectName = "خودشناسی"; break; }
                case 5: { SubjectName = "شکرگذاری"; break; }
            }
            string SearchSql = $"SELECT * FROM Books WHERE Subject=N'{SubjectName}'";
            await _booksStore.GetAllBooks(SearchSql);

        }
        #endregion
    }
}
