namespace ExemploCamadas.Application.Modules.Cliente.Interfaces.ServicesInterfaces;

public interface IClienteService
{
    Task<List<Domain.Entities.Cliente>> GetList();
}