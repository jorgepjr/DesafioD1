using Dominio;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> contextOptions) : base(contextOptions){}
        public DbSet<Cliente> Clientes { get; set; }
    }
}