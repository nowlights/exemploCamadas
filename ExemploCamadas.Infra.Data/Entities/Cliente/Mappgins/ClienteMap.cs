using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExemploCamadas.Infra.Data.Entities.Cliente.Mappgins;

public class ClienteMap : IEntityTypeConfiguration<Domain.Entities.Cliente>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.Cliente> builder)
    {
        builder.HasKey(x => x.IdCliente);
            //....
    }
}