using Microsoft.IdentityModel.Tokens;
using My_Library.Model;
using My_Library.Service;
using My_Library.Store;
using My_Library.ViewModel;
using System.Windows;

namespace My_Library.Command.BooksCommands
{
    public class EditBookCommand : CommandBase
    {
        #region Dependencies
        private IBooksStore _booksStore;
        private IBooksViewModel _booksViewModel;
        private BooksRepository _booksRepository;
        #endregion


        #region Contructor
        /// <summary>
        /// 
        /// </summary>
        /// <param name="booksViewModel"></param>
        /// <param name="booksStore"></param>
        /// <param name="booksRepository"></param>
        public EditBookCommand(IBooksViewModel booksViewModel, IBooksStore booksStore, BooksRepository booksRepository)
        {
            _booksStore = booksStore;
            _booksViewModel = booksViewModel;
            _booksRepository = booksRepository;
        }
        #endregion


        #region Execution
        /// <summary>
        ///  Checks To Validate Book Data First then Edite Selected Using BookStore Class.
        /// </summary>
        /// <param name="parameter">No Perameer Needed This Method Gets Its Data From BooksViewModel 
        /// Data : Name,Publisher,Subject,PublicationDate</param>
        public override async void Execute(object? parameter)
        {
            IBook SelectedBook = _booksViewModel.SelectedBook;
            if (SelectedBook == null)
            {
                MessageBox.Show("لطفا کتابی را برای ویرایش انتخاب کنید", "ویرایش کتاب");
            }

            if (_booksViewModel.Name.IsNullOrEmpty())
            {
                MessageBox.Show("لطفا نام کتاب را وارد کنید", "افزودن کتاب");
                return;
            }
            if (_booksViewModel.Publisher.IsNullOrEmpty())
            {
                MessageBox.Show("لطفا منتشرکننده کتاب را وارد کنید", "افزودن کتاب");
                return;
            }
            if (_booksViewModel.Subject.IsNullOrEmpty())
            {
                MessageBox.Show("لطفا نوع کتاب را وارد کنید", "افزودن کتاب");
                return;
            }
            if (_booksViewModel.PublicationDate.IsNullOrEmpty())
            {
                MessageBox.Show("لطفا تاریخ انتشار کتاب را وارد کنید", "افزودن کتاب");
                return;
            }
            int PublicationYear = 0;
            if (!int.TryParse(_booksViewModel.PublicationDate, out PublicationYear))
            {
                MessageBox.Show("لطفا تاریخ انتشار کتاب را عدد وارد کنید", "افزودن کتاب");
                _booksViewModel.PublicationDate = "";
                return;
            }



            SelectedBook.Name = _booksViewModel.Name;
            SelectedBook.Publisher = _booksViewModel.Publisher;
            SelectedBook.Subject = _booksViewModel.Subject;
            SelectedBook.PublicationDate = _booksViewModel.PublicationDate;
            SelectedBook.Tier = _booksViewModel.Tier;
            await _booksStore.EditBook(SelectedBook);
        }
        #endregion
    }
}
