using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HamperStoreWeb.ViewModels
{
    public class ProductEditViewModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public decimal Price { get; set; }
        public bool Discontinued { get; set; }
        public string Productdescription { get; set; }
    }
}
