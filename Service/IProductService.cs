using PokeStore.Model;
using System.Collections;

namespace PokeStore.Service;

public interface IProductService
{
    IList<Product> FindAllProducts();
    Product FindProduct(int id);
    void AddProduct(Product product);
    void EditProduct(Product product);
    void DeleteProduct(int id);
    IList<Brand> FindAllBrands();
}
