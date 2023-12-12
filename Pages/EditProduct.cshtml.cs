using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PokeStore.Model;
using PokeStore.Service;
using System.Text.RegularExpressions;

namespace PokeStore.Pages;

[Authorize]
public class EditProductModel : PageModel
{
    //PROPRIEDADE E ATRIBUTOS
    private IProductService _service;
    [BindProperty]
    public Product Product { get; set; }
    public SelectList BrandOptionItems { get; set; }

    //CONSTRUTOR
    public EditProductModel(IProductService productService)
    {
        _service = productService;
    }

    //MÉTODOS
    public void OnGet(int id)
    {
        Product = _service.FindProduct(id);
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

        _service.EditProduct(Product);

        return RedirectToPage("/List");

    }

    public IActionResult OnPostDelete()
    {
        _service.DeleteProduct(Product.ProductId);

        TempData["TempMensagemSucesso"] = true;

        return RedirectToPage("/List");
    }
}
