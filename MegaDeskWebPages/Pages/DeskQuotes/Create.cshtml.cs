using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MegaDeskWebPages.Models;

namespace MegaDeskWebPages.Pages.DeskQuotes
{
    public class CreateModel : PageModel
    {
        private readonly MegaDeskWebPages.Models.MegaDeskWebPagesContext _context;
        [BindProperty]
        public DeskQuote NewQuote { get; set; }
        public Desk Desk { get; set; }
        public Delivery Delivery { get; set; }
        public Material Material { get; set; }
        //select list for material 
        public SelectList MaterialList { get; set; }
        [BindProperty(SupportsGet = true)]
        public string MatListItem { get; set; }
        // select list for delivery 
        public SelectList DeliveryList { get; set; }
        [BindProperty(SupportsGet = true)]
        public string DelListItem { get; set; }
        public CreateModel(MegaDeskWebPages.Models.MegaDeskWebPagesContext context)
        {
          
            _context = context;
            IQueryable<string> matQuery = from m in _context.Material
                                          orderby m.MaterialType
                                       select m.MaterialType;

            IQueryable<string> delQuery = from d in _context.Delivery
                                          orderby d.RushOrderDay
                                          select d.RushOrderDay;

            MaterialList = new SelectList(matQuery.Distinct().ToList());
            DeliveryList = new SelectList(delQuery.Distinct().ToList());


        }

        public IActionResult OnGet()
        {
          ViewData["DeliveryID"] = new SelectList(_context.Set<Delivery>(), "DeliveryID", "DeliveryID");
          ViewData["DeskID"] = new SelectList(_context.Set<Desk>(), "DeskID", "DeskID");
            return Page();
        }

        

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            /////////////////////////////////////////////////////////////////////////////////////////
            /////////////////////////////////////////////////////////////////////////////////////////
            //
            //    START STAPLES AND GLUE CODE BLOCK 
            //
            /////////////////////////////////////////////////////////////////////////////////////////
            /////////////////////////////////////////////////////////////////////////////////////////
    
            //
            // Convery Material ID to price 
            //
            decimal materialPrice = NewQuote.Desk.MaterialID;
            switch (materialPrice)
            {
                case 1:
                    materialPrice = 200;
                    break;
                case 2:
                    materialPrice = 100;
                    break;
                case 3:
                    materialPrice = 50;
                    break;
                case 4:
                    materialPrice = 125; break;
                case 5:
                    materialPrice = 200; break;
                default:
                    materialPrice = 200; break;
            }
            //
            // Convert DeliveryID to DeliveryCost
            //
            decimal deliveryCost = NewQuote.DeliveryID;
            switch (deliveryCost)
            {
                case 1:
                    deliveryCost = 3;
                    break;
                case 2:
                    deliveryCost = 5;
                    break;
                case 3:
                    deliveryCost = 7;
                    break;
                default:
                    deliveryCost = 14; break;
            }


            NewQuote.QuoteDate = DateTime.Now;
            decimal Area =  NewQuote.Desk.surfaceArea();
            NewQuote.ShippingCost = calcShipPrice(deliveryCost, Area);
            NewQuote.DeskPrice = calcPrice(materialPrice,Area, NewQuote.ShippingCost, NewQuote.Desk.NumDrawers*25);



            decimal calcShipPrice(decimal pvRushDays, decimal pvArea)
            {

                decimal shippingPrice;


                if (pvRushDays == 3)
                {
                    if (pvArea < 1000)
                    {
                        shippingPrice = 60;
                    }
                    else if (pvArea < 2001)
                    {
                        shippingPrice = 70;
                    }
                    else
                    {
                        shippingPrice = 80;
                    }
                }
                else if (pvRushDays == 5)
                {
                    if (pvArea < 1000)
                    {
                        shippingPrice = 40;
                    }
                    else if (pvArea < 2001)
                    {
                        shippingPrice = 50;
                    }
                    else
                    {
                        shippingPrice = 60;
                    }
                }
                else if (pvRushDays == 7)
                {
                    if (pvArea < 1000)
                    {
                        shippingPrice = 30;
                    }
                    else if (pvArea < 2001)
                    {
                        shippingPrice = 35;
                    }
                    else
                    {
                        shippingPrice = 40;
                    }
                }
                else
                {
                    shippingPrice = 0;
                }

                return shippingPrice;
            }

                decimal calcPrice(decimal pvMaterialCost, decimal pvArea, decimal pvShippingCost, decimal pvDrawers)
            { 
                if (pvArea < 1000)
                    return 200 + pvShippingCost + pvMaterialCost + pvDrawers;
                else
                    return 200 + pvShippingCost + pvMaterialCost + pvArea + pvDrawers;


            }
            /////////////////////////////////////////////////////////////////////////////////////////
            /////////////////////////////////////////////////////////////////////////////////////////
            //
            //    END STAPLES AND GLUE CODE BLOCK 
            //
            /////////////////////////////////////////////////////////////////////////////////////////
            /////////////////////////////////////////////////////////////////////////////////////////


            _context.DeskQuote.Add(NewQuote);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}