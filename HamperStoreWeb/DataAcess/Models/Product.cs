using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HamperStoreWeb.DataAcess.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        [Required,StringLength(50)]
        public string ProductName { get; set; }
        [Required, MaxLength(10)]
        public int ProductCOde { get; set; }
        [Required, MaxLength(10)]
        public decimal Price { get; set; }
        [Required]
        public bool Discontinued { get; set; }
        //fk
        public int CategoryId { get; set; }
        //Added Virtual Property to Allow EF to Lazy-load Genre and Artist as Necessary
        public virtual Category Category { get; set; }
         


    }
}
