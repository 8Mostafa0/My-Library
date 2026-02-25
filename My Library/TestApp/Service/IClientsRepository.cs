using My_Library.Model;

namespace My_Library.Service
{
    public interface IClientsRepository
    {
        Task AddNewClientToDb(IClient client);
        Task DeleteClientToDb(IClient client);
        Task DeleteClientToDb(int clientId);
        Task EditeClientToDb(IClient client);
        Task<List<Client>> GetAllClients(string customSql = "");
        Task<IClient> GetClient(string customSql, string executionPart);
    }
}