using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MegaDeskWebPages.Models;

namespace MegaDeskWebPages.Pages.Materials
{
    public class DetailsModel : PageModel
    {
        private readonly MegaDeskWebPages.Models.MegaDeskWebPagesContext _context;

        public DetailsModel(MegaDeskWebPages.Models.MegaDeskWebPagesContext context)
        {
            _context = context;
        }

        public Material Material { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Material = await _context.Material.FirstOrDefaultAsync(m => m.MaterialID == id);

            if (Material == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
