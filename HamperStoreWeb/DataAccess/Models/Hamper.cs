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

        //fk - one customer many hampers
        public int CustomerId { get; set; }
        //fk - one HamperCategoryId many hampers
        public int HamperCategoryId { get; set; }

        //Added Virtual Property to Allow EF to Lazy-load Genre and Artist as Necessary
        public virtual HamperCategory HamperCategory { get; set; }
    }
}
