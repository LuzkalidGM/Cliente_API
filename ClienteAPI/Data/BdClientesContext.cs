using Microsoft.EntityFrameworkCore;

namespace ClienteAPI.Data
{
    public class BdClientesContext : DbContext
    {
        public BdClientesContext(DbContextOptions<BdClientesContext> options)
            : base(options)
        {
        }

        // Agrega aquí tus DbSet según las tablas que tengas
        // Por ejemplo:
        // public DbSet<Cliente> Clientes { get; set; }
        // public DbSet<TipoDocumento> TiposDocumentos { get; set; }
    }
}