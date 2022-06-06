using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Data
{
    public class DataContext : DbContext
    {
        public DbSet <Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Password=Rossum1921;Persist Security Info=True;User ID=sa;Initial Catalog=desafio;Data Source=RDXNTBRJ3089\\FALLOUT");
        }
    }
}
