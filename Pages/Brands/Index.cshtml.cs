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
    public class IndexModel : PageModel
    {
        private readonly PokeStore.Data.ProductDbContext _context;

        public IndexModel(PokeStore.Data.ProductDbContext context)
        {
            _context = context;
        }

        public IList<Brand> Brand { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.TableBrand != null)
            {
                Brand = await _context.TableBrand.ToListAsync();
            }
        }
    }
}
