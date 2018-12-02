using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HamperStoreWeb.DataAcess.Models
{
    public class Hamper
    {
        public int HamperId { get; set; }
        [Required, Display(Name ="Hamper Name")]
        public string HamperName { get; set; }
        [Required, Display(Name = "Price")]
        public decimal TotalPrice { get; set; }
        
        //relationships
        //1-* - one Hamper has many products
        //public ICollection<Product> Products { get; set; }
        ////1-* - one Customer has many hampers
        //public Customer Customer { get; set; }
        ////1-1 - one Hamper has one HamperCategory
        //public HamperCategory HamperCategory { get; set; }

    }
}
