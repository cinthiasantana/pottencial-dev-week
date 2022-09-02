using Microsoft.EntityFrameworkCore;
using src.Models;

namespace src.Persistence;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options
    ) : base(options)

    {

    }
    public DbSet<Pessoa> Pessoas { get; set; }
    public DbSet<Contrato> Contratos { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Pessoa>(x =>
        {
            x.HasKey(x => x.Id);
            x.HasMany(x => x.contratos)
            .WithOne()
            .HasForeignKey(x => x.PessoaId);
        });
        builder.Entity<Contrato>(x =>
        {
            x.HasKey(x => x.Id);
        });
    }
}