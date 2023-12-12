using PokeStore.Model;

namespace PokeStore.Service.Memory;

public class ProductService : IProductService
{
    //PROPRIEDADE E ATRIBUTOS
    private IList<Product> _products;

    //CONSTRUTOR
    public ProductService()
    {
        LoadInitialList();
    }

    //MÉTODOS
    private void LoadInitialList()
    {
        _products = new List<Product>()
        {
            new Product
            {
                ProductId = 1,
                ProductName = "PokeBola",
                ProductDescription = "Captura Pokémon selvagens.",
                ProductImage = "/images/PokeBall.png",
                RegistrationDate = DateTime.Now,
                IsAvailable = true,
                ProductPrice = 50.00,
            },
            new Product
            {
                ProductId = 2,
                ProductName = "Potion",
                ProductDescription = "Cura os Pokémon durante batalhas.",
                ProductImage = "/images/Potion.png",
                RegistrationDate = DateTime.Now,
                IsAvailable = true,
                ProductPrice = 10.00,
            },
            new Product
            {
                ProductId = 3,
                ProductName = "Revive",
                ProductDescription = "Revive Pokémon desmaiados.",
                ProductImage = "/images/Revive.png",
                RegistrationDate = DateTime.Now,
                IsAvailable = true,
                ProductPrice = 30.00,
            }
        };
    }

    public IList<Product> FindAllProducts() => _products;

    public Product FindProduct(int id)
    {
        return _products.SingleOrDefault(item => item.ProductId == id);
    }

    public void AddProduct(Product product)
    {
        var proximoNumero = _products.Max(item => item.ProductId) + 1;
        product.ProductId = proximoNumero;
        _products.Add(product);
    }

    public void EditProduct(Product product)
    {
        var productFound = FindProduct(product.ProductId);
        productFound.ProductName = product.ProductName;
        productFound.ProductDescription = product.ProductDescription;
        productFound.ProductImage = product.ProductImage;
        productFound.ProductPrice = product.ProductPrice;
        productFound.IsAvailable = product.IsAvailable;
        productFound.RegistrationDate = product.RegistrationDate;
    }

    public void DeleteProduct(int id)
    {
        var productFound = FindProduct(id);
        _products.Remove(productFound);
    }

    public IList<Brand> FindAllBrands()
    {
        throw new NotImplementedException();
    }
}
