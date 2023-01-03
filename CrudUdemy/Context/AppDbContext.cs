using CrudUdemy.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudUdemy.Context
{
    public class AppDbContext : DbContext
    {
           
        public AppDbContext (DbContextOptions options) : base(options)
        {

        }

        public DbSet <Gestor> gestores_bd { get; set; }
    }
}
