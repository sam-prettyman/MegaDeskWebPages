using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MegaDeskWebPages.Models
{
    public class DeskQuote
    {
        const decimal BASE_PRICE = 200;

        public int DeskQuoteID { get; set; }
        //link desk
        public int DeskID { get; set; }
        public Desk Desk { get; set; }
        // link delivery 
        public int DeliveryID { get; set; }
        public Delivery Delivery { get; set; }
        public string CustomerName { get; set; }

        [DataType(DataType.Date)]
        public DateTime QuoteDate { get; set; }
        public decimal ShippingCost { get; set; }
        public decimal DeskPrice { get; set; }

        //
        // create new deskQuote from addQuote variables
        //

        public DeskQuote()
        {

        }
        /*
         public DeskQuote(Delivery newDelivery, string name)
             {
                 this.QuoteDate = DateTime.Now;
                 
                 int RushDays = newDelivery.Days;
                 this.CustomerName = name;
                 this.QuoteDate = DateTime.Now;
                 decimal area = Desk.surfaceArea();
                 this.ShippingCost = calcshippingCost(RushDays, area);
                 decimal materialCost = this.Desk.Material.Price;
                 this.DeskPrice = calcDeskPrice(materialCost, area, this.ShippingCost);
             }
             */

        //
        // Calculate Shipping Cost 
        //
        public decimal calcshippingCost(decimal pvRushDays, decimal pvArea)
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
                    shippingPrice = 45;
                }
                else
                {
                    shippingPrice = 60;
                }
            }
            else
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
            return shippingPrice;

        }


        //
        // Calculate the cost of the desk
        //
        public decimal calcDeskPrice(decimal pvMaterialCost, decimal pvArea, decimal pvShippingCost)
        {
            if (pvArea < 1000)
                return BASE_PRICE + pvShippingCost + pvMaterialCost;
            else
                return BASE_PRICE + pvShippingCost + pvMaterialCost + pvArea;


        }

    }

}


