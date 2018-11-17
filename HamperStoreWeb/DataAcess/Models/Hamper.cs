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
        [Required]
        public string HamperName { get; set; }
        [Required]
        public decimal TotalPrice { get; set; }

        //fk - one customer many hampers
        public int CustomerId { get; set; }
    }
}
