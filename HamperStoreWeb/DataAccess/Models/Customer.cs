using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace HamperStoreWeb.DataAcess.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        [Required, MaxLength(6)]
        public string Title { get; set; }
        [Required, MaxLength(50), Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required, MaxLength(50), Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required, MaxLength(8), Display(Name = "Date of Birth")]
        public DateTime DOB { get; set; }
        [Required, MaxLength(10), Display(Name = "Contact Number")]
        public string Phone { get; set; }
        [Required, MaxLength(100), Display(Name = "Residential Address")]
        public string Address { get; set; }

        //relationships
        //1-* - one Customer has many hampers
        public ICollection<Hamper> Hampers { get; set; }



    }
}
