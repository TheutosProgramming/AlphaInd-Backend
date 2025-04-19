using Business.Factories;
using Business.Models;
using Data.Repositories;

namespace Business.Services;

public interface IClientService
{
    Task<IEnumerable<Client>> GetClientsAsync();
    Task<Client> GetClientsByIdAsync(string id);
    Task<Client> GetClientsByNameAsync(string clientName);
}

public class ClientService(IClientRepository clientRepository) : IClientService
{
    private readonly IClientRepository _clientRepository = clientRepository;

    public async Task<IEnumerable<Client>> GetClientsAsync()
    {
        var entities = await _clientRepository.GetAllAsync(sortBy: x => x.ClientName);

        var clients = entities.Select(ClientFactory.ToModel);

        return clients;
    }

    public async Task<Client> GetClientsByIdAsync(string id)
    {
        var clients = await _clientRepository.GetAsync(x => x.Id == id);
        return clients == null ? null! : ClientFactory.ToModel(clients);
    }

    public async Task<Client> GetClientsByNameAsync(string clientName)
    {
        var clients = await _clientRepository.GetAsync(x => x.ClientName.ToLower() == clientName.ToLower());
        return clients == null ? null! : ClientFactory.ToModel(clients);
    }
}
