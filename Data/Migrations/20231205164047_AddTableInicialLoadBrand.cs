using Microsoft.EntityFrameworkCore.Migrations;
using PokeStore.Data;
using PokeStore.Model;

#nullable disable

namespace PokeStore.Migrations
{
    /// <inheritdoc />
    public partial class AddTableInicialLoadBrand : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var context = new ProductDbContext();
            context.TableBrand.AddRange(FindInitialLoad());
            context.SaveChanges();
        }

        private IList<Brand> FindInitialLoad()
        {
            return new List<Brand>()
            {
                new Brand() {BrandDescription = "Fire Team"},
                new Brand() {BrandDescription = "Aqua Team"},
                new Brand() {BrandDescription = "Rocket Team"},
            };
        }
    }
}
