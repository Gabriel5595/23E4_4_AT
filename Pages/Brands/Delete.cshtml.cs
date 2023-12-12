using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PokeStore.Data;
using PokeStore.Model;

namespace PokeStore.Pages.Brands
{
    public class DeleteModel : PageModel
    {
        private readonly PokeStore.Data.ProductDbContext _context;

        public DeleteModel(PokeStore.Data.ProductDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Brand Brand { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.TableBrand == null)
            {
                return NotFound();
            }

            var brand = await _context.TableBrand.FirstOrDefaultAsync(m => m.BrandId == id);

            if (brand == null)
            {
                return NotFound();
            }
            else 
            {
                Brand = brand;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.TableBrand == null)
            {
                return NotFound();
            }
            var brand = await _context.TableBrand.FindAsync(id);

            if (brand != null)
            {
                Brand = brand;
                _context.TableBrand.Remove(Brand);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
