using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PokeStore.Model;

namespace PokeStore.Data;

public class ProductDbContext : IdentityDbContext
{
    public DbSet<Product> TableProduct { get; set; }
    public DbSet<Brand> TableBrand { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        string conn = config.GetConnectionString("Conn");

        optionsBuilder.UseSqlServer(conn);
    }
}
