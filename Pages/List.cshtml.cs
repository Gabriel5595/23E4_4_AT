using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PokeStore.Model;
using PokeStore.Service;

namespace PokeStore.Pages;

public class ListModel : PageModel
{
    //PROPRIEDADES E ATRIBUTOS
    private IProductService _service;
    public IList<Product> ProductList { get; private set; }

    //CONSTRUTOR
    public ListModel(IProductService productService)
    {
        _service = productService;
    }

    //MÉTODOS
    public void OnGet()
    {
        ViewData["Title"] = "Lista de Produtos";

        ProductList = _service.FindAllProducts();
    }
}
