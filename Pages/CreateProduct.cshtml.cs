using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PokeStore.Model;
using PokeStore.Service;

namespace PokeStore.Pages;

[Authorize]
public class CreateProductModel : PageModel
{
    //PROPRIEDADES E ATRIBUTOS
    private IProductService _service;

    [BindProperty]
    public Product Product { get; set; }

    public SelectList BrandOptionItems {  get; set; }
    
    //CONSTRUTOR
    public CreateProductModel(IProductService productService)
    {
        _service = productService;
    }

    //MÉTODOS
    public void OnGet()
    {
        BrandOptionItems = new SelectList(_service.FindAllBrands(),
            nameof(Brand.BrandId),
            nameof(Brand.BrandDescription));
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _service.AddProduct(Product);

        return RedirectToPage("/List");
    }
}
