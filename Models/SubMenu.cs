using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShopApi.Models
{
    public class SubMenu
    {
        public int Id { get; set; }        
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(100)]
        public string Description { get; set; }
        [Required]        
        public int Price { get; set; }
        [Required]
        public string Image { get; set; }
       
    }
}
