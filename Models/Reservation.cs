using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShopApi.Models
{
    public class Reservation
    {
        public int Id { get; set; }        
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        [Required]
        [StringLength(50)]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")]
        public string Email { get; set; }
        [Required]
        [StringLength(50)]
        [RegularExpression("^[0-9]*$")]
        public string Phone { get; set; }
        [Required]
        [StringLength(50)]
        public string TotalPersons { get; set; }
        [Required]        
        public DateTime Date { get; set; }
        [Required]
        [DataType(DataType.Time)]
        public string Time { get; set; }
    }
}
