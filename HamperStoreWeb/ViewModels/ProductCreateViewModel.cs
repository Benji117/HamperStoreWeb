using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using HamperStoreWeb.DataAcess.Models;


namespace HamperStoreWeb.ViewModels
{
    public class ProductCreateViewModel : Product
    {
        public int ProductId { get; set; }
        [Required,Display(Name ="Product Name")]
        public string ProductName { get; set; }
        //[Required, MaxLength(10), HiddenInput(DisplayValue = false)]
        //public int ProductCOde { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public bool Discontinued { get; set; }       
        public List<Category> categoriesList { get; set; }



    }
}
