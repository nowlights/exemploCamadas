using ExemploCamadas.Application.Modules.Cliente.Interfaces.RepositoryInterfaces;
using ExemploCamadas.Application.Modules.Cliente.Interfaces.ServicesInterfaces;

namespace ExemploCamadas.Application.Modules.Cliente.Services;

public class ClienteService(
    IClienteRepository _clienteRepository
    ) : IClienteService
{
    public async Task<List<Domain.Entities.Cliente>> GetList()
    {
        return await _clienteRepository.FindListAsync(x=> true);
    }
}