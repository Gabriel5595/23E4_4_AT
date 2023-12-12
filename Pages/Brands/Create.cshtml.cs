using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PokeStore.Data;
using PokeStore.Model;

namespace PokeStore.Pages.Brands
{
    public class CreateModel : PageModel
    {
        private readonly PokeStore.Data.ProductDbContext _context;

        public CreateModel(PokeStore.Data.ProductDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Brand Brand { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.TableBrand == null || Brand == null)
            {
                return Page();
            }

            _context.TableBrand.Add(Brand);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
