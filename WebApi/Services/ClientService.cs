using WebApi.Data.Entities;
using WebApi.Data.Repositories;
using WebApi.Models;

namespace WebApi.Services;

public class ClientService(ClientRepository clientRepository)
{
    private readonly ClientRepository _clientRepository = clientRepository;

    public async Task<bool> CreateClientAsync(AddClientFormData clientFormData)
    {
        if (clientFormData == null)
            return false;

        var entity = new ClientEntity
        {
            ClientName = clientFormData.ClientName
        };

        var result = await _clientRepository.AddAsync(entity);
        return result;
    }

    public async Task<bool> UpdateClientAsync(UpdateClientFormData clientFormData)
    {
        if (clientFormData == null)
            return false;

        var entity = new ClientEntity
        {
            Id = clientFormData.Id,
            ClientName = clientFormData.ClientName
        };

        var result = await _clientRepository.UpdateAsync(entity);
        return result;
    }

    public async Task<bool> DeleteClientAsync(string clientId)
    {
        if (string.IsNullOrEmpty(clientId))
            return false;

        var result = await _clientRepository.DeleteAsync(x => x.Id == clientId);
        return result;
    }

    public async Task<IEnumerable<Client>> GetAllClientsAsync()
    {
        var entities = await _clientRepository.GetAllAsync();
        var clients = entities.Select(client => new Client
        {
            Id = client.Id,
            ClientName = client.ClientName
        });

        return clients;
    }

    public async Task<Client?> GetClientByIdAsync(string clientId)
    {
        var entity = await _clientRepository.GetAsync(x => x.Id == clientId);
        return entity == null ? null : new Client
        {
            Id = entity.Id,
            ClientName = entity.ClientName
        };
    }
}
