using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace HamperStoreWeb.DataAcess.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        [Required, Display(Name = "Category Name")]
        public string CategoryName { get; set; }

        //relationships
        //1-1 - one Product has one Category - Foreign Key and Nav Property
        //public int ProductId { get; set; }
        //public Product Product { get; set; }




    }
}
