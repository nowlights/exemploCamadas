using ExemploCamadas.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExemploCamadas.Infra.Data.ApplicationDbContext;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Cliente> cliente { get; set; }
}