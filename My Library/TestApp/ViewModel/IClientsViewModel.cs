using My_Library.Command;
using My_Library.Command.ClientsCommands;
using My_Library.Model;
using My_Library.Service;
using My_Library.Store;
using System.Windows.Input;

namespace My_Library.ViewModel
{
    public interface IClientsViewModel : IViewModelBase
    {
        ICommand AddNewClientCommand { get; }
        IEnumerable<IClient> Clients { get; }
        ICommand DeleteClientCommand { get; }
        IEditClientCommand EditClientCommand { get; }
        string FirstName { get; set; }
        string LastName { get; set; }
        ILoadClientsCommand LoadClientsCommand { get; }
        IOrderClientsCommand OrderClientsCommand { get; }
        IReloadClientsCommand ReloadClientsCommand { get; }
        IClient SelectedClient { get; set; }
        string SortOrder { get; set; }
        int Tier { get; set; }

        static abstract IClientsViewModel LoadViewModel(IClientsStore clientStore, ILoanRepository loanRepository, IReservedBooksRepository reservedBooksRepository);
        void UpdateClients();
    }
}