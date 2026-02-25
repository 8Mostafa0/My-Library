using My_Library.Model;
using My_Library.Store;
using My_Library.ViewModel;
using System.Windows;

namespace My_Library.Command.ClientsCommands
{
    public class AddNewClientCommand : CommandBase, IAddNewClientCommand
    {
        #region Dependencies
        private readonly IClientsStore _clientStore;
        private readonly IClientsViewModel _clientViewModel;
        #endregion

        #region Contructor
        /// <summary>
        /// Checks To Validate Clients Data First Then Add New Client Using Clients Store
        /// </summary>
        /// <param name="clientsViewModel"></param>
        /// <param name="clientStore"></param>
        public AddNewClientCommand(IClientsViewModel clientsViewModel, IClientsStore clientStore)
        {
            _clientStore = clientStore;
            _clientViewModel = clientsViewModel;
        }
        #endregion


        #region Execcution
        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameter">No Perameer Needed</param>
        public override async void Execute(object? parameter)
        {
            if (string.IsNullOrEmpty(_clientViewModel.FirstName))
            {
                MessageBox.Show("لطفا ابتدا نام را وارد کنید", "افزودن کاربر");
                return;
            }
            if (string.IsNullOrEmpty(_clientViewModel.LastName))
            {
                MessageBox.Show("لطفا ابتدا فامیلی را وارد کنید", "افزودن کاربر");
                return;
            }
            IClient client = new Client()
            {
                FirstName = _clientViewModel.FirstName,
                LastName = _clientViewModel.LastName,
                Tier = _clientViewModel.Tier,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            };
            await _clientStore.AddNewClient(client);

        }
        #endregion
    }
}
