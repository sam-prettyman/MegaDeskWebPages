using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MegaDeskWebPages.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MegaDeskWebPagesContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MegaDeskWebPagesContext>>()))
            {
                // Look for any movies.
                if (context.Material.Any())
                {
                    return;   // DB has been seeded
                }

                context.Material.AddRange(
                    new Material
                    {
                        MaterialType = "Oak",
                        Price = 200
                    },
                    new Material
                  {
                        MaterialType = "Laminate",
                        Price = 100
                    },
                     new Material
                     {
                        MaterialType = "Pine",
                        Price = 50
                    },
                     new Material
                     {
                        MaterialType = "Veneer",
                        Price = 125
                    },
                     new Material
                     {
                        MaterialType = "Oak",
                        Price = 200
                    }
                );

                context.Delivery.AddRange(
                    new Delivery
                    {
                        RushOrderDay = "3 Day",
                        Days = 3
                    },
                     new Delivery
                     {
                         RushOrderDay = "5 Day",
                         Days = 5
                     },
                    new Delivery
                    {
                         RushOrderDay = "7 Day",
                         Days = 7
                     },
                     new Delivery
                     {
                         RushOrderDay = "14 Day (Normal Shipping)",
                         Days = 14
                     }
                    );
                /*
                    context.Desk.AddRange(
                     new Desk
                     {
                         Width = 24,
                         Depth = 12,
                         NumDrawers = 0,
                         MaterialID = 1
                     },
                      new Desk
                      {
                          Width = 96,
                          Depth = 48,
                          NumDrawers = 7,
                          MaterialID = 3
                      },
                      new Desk
                      {
                          Width = 36,
                          Depth = 50,
                          NumDrawers = 3,
                          MaterialID = 4
                      },
                      new Desk
                      {
                          Width = 24,
                          Depth = 12,
                          NumDrawers = 7,
                          MaterialID = 3
                      }
                   );
                context.DeskQuote.AddRange(
                    new DeskQuote
                    {
                        DeskID = 1,
                        DeliveryID = 1,
                        CustomerName = "Breena Jones",
                        QuoteDate = DateTime.Now,


                    },
                     new DeskQuote
                     {
                         DeskID = 2,
                         DeliveryID = 2,
                         CustomerName = "Sam Prettyman",
                         QuoteDate = DateTime.Now,


                     },
                    new DeskQuote
                    {
                        DeskID = 3,
                        DeliveryID = 3,
                        CustomerName = "Chris Cole",
                        QuoteDate = DateTime.Now,


                    },
                     new DeskQuote
                     {
                         DeskID = 4,
                         DeliveryID = 1,
                         CustomerName = "Louis Lane",
                         QuoteDate = DateTime.Now,


                     }
                  );
                  */
                context.SaveChanges();
            }
        }
    }
}
