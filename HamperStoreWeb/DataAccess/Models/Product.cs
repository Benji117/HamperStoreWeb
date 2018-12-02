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
        [Required,StringLength(50), Display(Name = "Product Name")]
        public string ProductName { get; set; }
        [Required, MaxLength(10), Display(Name = "Product Code")]
        public string ProductCode { get; set; }
        [Required, MaxLength(10), Display(Name = "Price")]
        public decimal Price { get; set; }
        
        public bool Discontinued { get; set; }
        [Required, StringLength(200), Display(Name = "Product Description")]
        public string Productdescription { get; set; }

        //relationships
        //fk - 1-* Hamper has many products - No foreign Key
        //public Hamper Hamper { get; set; }
        ////1-1 - one Product has one Category
        //public Category Category { get; set; }

    }
}
