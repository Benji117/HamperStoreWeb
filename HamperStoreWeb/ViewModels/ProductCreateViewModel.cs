using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using HamperStoreWeb.DataAcess.Models;


namespace HamperStoreWeb.ViewModels
{
    public class ProductCreateViewModel
    {
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public decimal Price { get; set; }
        public bool Discontinued { get; set; }
        public string Productdescription { get; set; }
        //public List<Category> categoriesList { get; set; }



    }
}
