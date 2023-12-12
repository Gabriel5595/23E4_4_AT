using PokeStore.Data;
using PokeStore.Model;
using System.Text.RegularExpressions;

namespace PokeStore.Service.Data;

public class ProductService : IProductService
{
    //PROPRIEDADES E ATRIBUTOS
    private ProductDbContext _context;

    //CONSTRUTOR
    public ProductService(ProductDbContext context)
    {
        _context = context;
    }

    //MÉTODO
    public IList<Product> FindAllProducts()
    {
        return _context.TableProduct.ToList();
    }

    public Product FindProduct(int id)
    {
        return _context.TableProduct.SingleOrDefault(item => item.ProductId == id);
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
        productFound.BrandId = product.BrandId;
        _context.SaveChanges();
    }

    public void DeleteProduct(int id)
    {
        var productFound = FindProduct(id);
        _context.TableProduct.Remove(productFound);
        _context.SaveChanges();
    }

    public void AddProduct(Product product)
    {
        _context.TableProduct.Add(product);
        _context.SaveChanges();
    }

    public IList<Brand> FindAllBrands()
    {
        return _context.TableBrand.ToList();
    }
    

    
}
