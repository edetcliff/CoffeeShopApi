using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShopApi.Models
{
    public class Menu
    {
        public int Id { get; set; }       
        [Required]
        public string Name { get; set; }
        [Required]
        public string Image { get; set; }
        public ICollection<SubMenu> SubMenu { get; set; }

    }

}
