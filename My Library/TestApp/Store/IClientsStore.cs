using My_Library.Model;

namespace My_Library.Store
{
    public interface IClientsStore
    {
        IEnumerable<IClient> Clients { get; }
        string SearchClientName { get; set; }

        event Action<IClient> ClientAdded;
        event Action<IClient> ClientEdited;
        event Action<IClient> ClientRemoved;
        event Action ClientsUpdated;

        Task AddNewClient(IClient client);
        Task DeleteClient(IClient client);
        Task EditClient(IClient client);
        Task GetOrderedClients(string customSql = "");
        Task Load();
    }
}