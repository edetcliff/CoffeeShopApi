using CoffeeShopApi.Data;
using CoffeeShopApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoffeeShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubMenuController : ControllerBase
    {
        CoffeeShopApiDbContext Context;
        public SubMenuController(CoffeeShopApiDbContext DbContext)
        {
            Context = DbContext;
        }


        //The following routes is for ADMIN only

        // PUT api/<SubMenuController>/5
        [HttpPut("{Id}")]
        public IActionResult Put(int Id, [FromBody] SubMenu subMenu)
        {
            var entity = Context.SubMenu.Find(Id);
            if (entity == null)
            {
                return NotFound("Record was not found");
            }
            else
            {
                entity.Name = subMenu.Name;
                entity.Description = subMenu.Description;
                entity.Image = subMenu.Image;
                entity.Price = subMenu.Price;
                Context.SaveChanges();
                return Ok("Record Updated Successfully");
            }
        }

        // DELETE api/<SubMenuController>/5
        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            var entity = Context.SubMenu.Find(Id);
            Context.Remove(entity);
            Context.SaveChanges();
            return Ok("SubMenu Deleted Successfully");
        }
    }
}
