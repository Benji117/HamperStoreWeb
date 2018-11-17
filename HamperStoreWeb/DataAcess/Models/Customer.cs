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
        [Required, MaxLength(50)]
        public string FirstName { get; set; }
        [Required, MaxLength(50)]
        public string LastName { get; set; }
        [Required, MaxLength(8)]
        public DateTime DOB { get; set; }
        [Required, MaxLength(10)]
        public string Phone { get; set; }
        [Required, MaxLength(100)]
        public string Address { get; set; }
        //Foreign Key
        public ICollection<Hamper> Hampers { get; set; }



    }
}
