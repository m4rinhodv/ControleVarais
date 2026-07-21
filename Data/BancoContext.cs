using Microsoft.EntityFrameworkCore;
using ControleVarais.Models;

namespace ControleVarais.Data;

public class BancoContext : DbContext
{
    public BancoContext(DbContextOptions<BancoContext> options) : base(options)
    { }

    public DbSet<ClientesModels> Clientes { get; set; }

}