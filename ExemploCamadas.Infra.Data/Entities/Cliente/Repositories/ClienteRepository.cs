using ExemploCamadas.Infra.Data.ApplicationDbContext;
using ExemploCamadas.Infra.Data.Base;

namespace ExemploCamadas.Infra.Data.Entities.Cliente.Repositories;

public class ClienteRepository(AppDbContext context) : RepositoryBase<Domain.Entities.Cliente>(context)
{
}