using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MegaDeskWebPages.Models;

namespace MegaDeskWebPages.Models
{
    public class MegaDeskWebPagesContext : DbContext
    {
        

        public MegaDeskWebPagesContext (DbContextOptions<MegaDeskWebPagesContext> options)
            : base(options)
        {
        }

        public DbSet<MegaDeskWebPages.Models.DeskQuote> DeskQuote { get; set; }

        public DbSet<MegaDeskWebPages.Models.Delivery> Delivery { get; set; }

        public DbSet<MegaDeskWebPages.Models.Desk> Desk { get; set; }

        public DbSet<MegaDeskWebPages.Models.Material> Material { get; set; }
 
    }
}
