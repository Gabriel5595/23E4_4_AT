using Microsoft.EntityFrameworkCore.Migrations;
using PokeStore.Data;
using PokeStore.Model;

#nullable disable

namespace PokeStore.Migrations
{
    /// <inheritdoc />
    public partial class AddTableInitialLoadProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var context = new ProductDbContext();
            context.TableProduct.AddRange(FindInitialLoad());
            context.SaveChanges();
        }

        private IList<Product> FindInitialLoad()
        {
            return new List<Product>()
            {
                new Product
                {
                    ProductName = "PokeBola",
                    ProductDescription = "Captura Pokémon selvagens.",
                    ProductImage = "/images/PokeBall.png",
                    RegistrationDate = DateTime.Now,
                    IsAvailable = true,
                    ProductPrice = 50.00,
                },
                new Product
                {
                    ProductName = "Potion",
                    ProductDescription = "Cura os Pokémon durante batalhas.",
                    ProductImage = "/images/Potion.png",
                    RegistrationDate = DateTime.Now,
                    IsAvailable = true,
                    ProductPrice = 10.00,
                },
                new Product
                {
                    ProductName = "Revive",
                    ProductDescription = "Revive Pokémon desmaiados.",
                    ProductImage = "/images/Revive.png",
                    RegistrationDate = DateTime.Now,
                    IsAvailable = true,
                    ProductPrice = 30.00,
                }
            };
        }
    }
}
