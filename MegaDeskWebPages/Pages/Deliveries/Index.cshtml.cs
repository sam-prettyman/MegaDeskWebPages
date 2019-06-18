using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MegaDeskWebPages.Models;

namespace MegaDeskWebPages.Pages.Deliveries
{
    public class IndexModel : PageModel
    {
        private readonly MegaDeskWebPages.Models.MegaDeskWebPagesContext _context;

        public IndexModel(MegaDeskWebPages.Models.MegaDeskWebPagesContext context)
        {
            _context = context;
        }

        public IList<Delivery> Delivery { get;set; }

        public async Task OnGetAsync()
        {
            Delivery = await _context.Delivery.ToListAsync();
        }
    }
}
