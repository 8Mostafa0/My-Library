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
        ICommand EditClientCommand { get; }
        string FirstName { get; set; }
        string LastName { get; set; }
        ICommand LoadClientsCommand { get; }
        ICommand OrderClientsCommand { get; }
        ICommand ReloadClientsCommand { get; }
        IClient SelectedClient { get; set; }
        string SortOrder { get; set; }
        int Tier { get; set; }

        static abstract IClientsViewModel LoadViewModel(IClientsStore clientStore, LoanRepository loanRepository, ReservedBooksRepository reservedBooksRepository);
        void UpdateClients();
    }
}