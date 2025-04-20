using WebApi.Data.Repositories;
using WebApi.Models;

namespace WebApi.Services;

public class ClientService(ClientRepository clientRepository)
{
    private readonly ClientRepository _clientRepository = clientRepository;

    //Hämtar alla clients och mappar de
    public async Task<IEnumerable<Client>> GetAllClientsAsync()
    {
        var entities = await _clientRepository.GetAllAsync();
        var clients = entities.Select(client => new Client { Id = client.Id, ClientName = client.ClientName });
        return clients;
    }
}
