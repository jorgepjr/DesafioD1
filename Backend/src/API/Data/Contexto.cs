using Dominio;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class Contexto : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
    }
}