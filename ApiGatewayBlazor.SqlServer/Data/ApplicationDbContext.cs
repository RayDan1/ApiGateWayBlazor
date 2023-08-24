using ApiGatewayBlazor.SqlServer.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiGatewayBlazor.SqlServer.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        //Aqui van los Modelos
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Venta> Ventas { get; set; }
    }
}