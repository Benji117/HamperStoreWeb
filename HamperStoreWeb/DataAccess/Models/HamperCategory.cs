using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HamperStoreWeb.DataAcess.Models
{
    public class HamperCategory
    {
        public int HamperCategoryId { get; set; }
        [Required, Display(Name = "Category Name")]
        public string HamperCategoryName { get; set; }
        public bool Discontinued { get; set; }

        //fk
        public int HamperId { get; set; }
    }
}
