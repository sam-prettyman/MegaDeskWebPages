using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MegaDeskWebPages.Models;

namespace MegaDeskWebPages.Pages.DeskQuotes
{
    public class DetailsModel : PageModel
    {
        private readonly MegaDeskWebPages.Models.MegaDeskWebPagesContext _context;

        public DetailsModel(MegaDeskWebPages.Models.MegaDeskWebPagesContext context)
        {
            _context = context;
        }

        public DeskQuote DeskQuote { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DeskQuote = await _context.DeskQuote
                .Include(d => d.Delivery)
                .Include(d => d.Desk).FirstOrDefaultAsync(m => m.DeskQuoteID == id);

            if (DeskQuote == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
