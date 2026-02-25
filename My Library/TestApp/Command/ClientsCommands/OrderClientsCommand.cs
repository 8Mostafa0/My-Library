using My_Library.Store;
using My_Library.ViewModel;

namespace My_Library.Command.ClientsCommands
{
    public class OrderClientsCommand : CommandBase
    {
        #region Dependencies
        private readonly ClientsStore _clitentsStore;
        private readonly ClientsViewModel _clientsViewModel;
        #endregion

        #region Contructor
        /// <summary>
        /// order clients based on tier
        /// </summary>
        /// <param name="clientsStore"></param>
        /// <param name="clientsViewModel"></param>
        public OrderClientsCommand(ClientsStore clientsStore, ClientsViewModel clientsViewModel)
        {
            _clitentsStore = clientsStore;
            _clientsViewModel = clientsViewModel;
        }
        #endregion

        #region Execution

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameter">no marametes needed</param>
        public override async void Execute(object? parameter)
        {
            string customSql = $"SELECT * FROM Clients WHERE Tier = '{_clientsViewModel.SortOrder}'";
            await _clitentsStore.GetOrderedClients(customSql);
        }
        #endregion
    }
}
