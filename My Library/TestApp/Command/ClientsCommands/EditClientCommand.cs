using My_Library.Model;
using My_Library.Store;
using My_Library.ViewModel;
using System.Windows;

namespace My_Library.Command.ClientsCommands
{
    public class EditClientCommand : CommandBase, IEditClientCommand
    {
        #region Dependencies
        private IClientsStore _clientsStore;
        private IClientsViewModel _clientsViewModel;
        #endregion

        #region Contructor
        /// <summary>
        ///  validate selected client then input values the edite client using clients store
        /// </summary>
        /// <param name="clientsViewModel"></param>
        /// <param name="clientsStore"></param>
        public EditClientCommand(IClientsViewModel clientsViewModel, IClientsStore clientsStore)
        {
            _clientsViewModel = clientsViewModel;
            _clientsStore = clientsStore;
        }
        #endregion


        #region Execution
        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameter">no parametes needed</param>
        public override async void Execute(object? parameter)
        {
            IClient client = _clientsViewModel.SelectedClient;
            if (client == null)
            {
                MessageBox.Show("لطفا کاربری را برای ویرایش انتخاب کنید", "ویرایش کاربر");
                return;
            }
            if (string.IsNullOrEmpty(_clientsViewModel.FirstName))
            {
                MessageBox.Show("لطفا ابتدا نام را وارد کنید", "ویرایش کاربر");
                return;
            }
            if (string.IsNullOrEmpty(_clientsViewModel.LastName))
            {
                MessageBox.Show("لطفا ابتدا فامیلی را وارد کنید", "ویرایش کاربر");
                return;
            }
            client.FirstName = _clientsViewModel.FirstName;
            client.LastName = _clientsViewModel.LastName;
            client.Tier = _clientsViewModel.Tier;
            await _clientsStore.EditClient(client);
        }
        #endregion
    }
}
