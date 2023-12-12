using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PokeStore.Model;
using PokeStore.Service;

namespace PokeStore.Pages
{
    public class DetailModel : PageModel
    {
        //PROPRIEDADES E ATRIBUTOS
        private IProductService _service;
        public Product Product { get; private set; }
        public Brand Brand { get; private set; }

        //CONSTRUTOR
        public DetailModel(IProductService productService)
        {
            _service = productService;
        }
        
        //MÉTODOS
        public IActionResult OnGet(int id)
        {
            Product = _service.FindProduct(id);
            Brand = _service.FindAllBrands().SingleOrDefault(item  => item.BrandId == Product.BrandId);

            if (Product == null)
            {
                return NotFound();
            }
            else
            {
                return Page();
            }

        }
    }
}
