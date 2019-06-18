using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MegaDeskWebPages.Models
{
    public class Desk
    {
        public int DeskID { get; set; }
        [Range(24, 96)]
        public int Width { get; set; }

        [Range(12, 48)]
        public int Depth { get; set; }

        [Display(Name = "Number of Drawers")]
        [Range(0, 7)]
        public int NumDrawers { get; set; }

        [Display(Name = "Material ID")]
        public int MaterialID { get; set; }
        public Material Material { get; set; }

        // Non-Default Constructor 
       /*  public Desk(int newWidth, int newDepth, int newDrawers, Material newMaterial)
         {
             this.Width = newWidth;
             this.Depth = newDepth;
             this.NumDrawers = newDrawers;
             this.Material = newMaterial;
         }
         */
     
        public decimal surfaceArea()
        {
            return Width * Depth;
        }



    }
}
