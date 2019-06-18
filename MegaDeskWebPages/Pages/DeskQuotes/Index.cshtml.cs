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
    public class IndexModel : PageModel
    {
        private readonly MegaDeskWebPages.Models.MegaDeskWebPagesContext _context;

        public IndexModel(MegaDeskWebPages.Models.MegaDeskWebPagesContext context)
        {
            _context = context;
        }

        public IList<DeskQuote> DeskQuote { get;set; }
        public IList<Material> Material { get; set; }
        public IList<Desk> Desk { get; set; }
        public IList<Delivery> Delivery { get; set; }


        public async Task OnGetAsync()
        {
            DeskQuote = await _context.DeskQuote
                .Include(d => d.Delivery)
                .Include(d => d.Desk).ToListAsync();
        }
    }
}
