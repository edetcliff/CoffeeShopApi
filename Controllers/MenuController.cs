using CoffeeShopApi.Data;
using CoffeeShopApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoffeeShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
         CoffeeShopApiDbContext Context;
        public MenuController(CoffeeShopApiDbContext DbContext)
        {
            Context = DbContext;
        }
        // GET: api/<MenuController>
        [HttpGet]
        public IActionResult Get()
        {
            var Menu = Context.Menu.Include("SubMenu");
            return Ok(Menu);
        }
       

        // GET api/<MenuController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int Id)
        {
            var Menu = Context.Menu.Include("SubMenu").FirstOrDefault(x => x.Id == Id);
            if(Menu == null)
            {
                return NotFound();
            }
            return Ok(Menu);
        }

        // POST api/<MenuController>
        [HttpPost]
        public IActionResult Post([FromBody] Menu menu)
        {
            Context.Add(menu);
            Context.SaveChanges();
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT api/<MenuController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int Id, [FromBody] Menu menu)
        {
            var entity = Context.Menu.Find(Id);
            if(entity == null)
            {
                return NotFound("Record was not found");
            }
            else
            {
                entity.Name = menu.Name;
                entity.Image = menu.Image;
                Context.SaveChanges();
                return Ok("Record Updated Successfully");
            }
        }

        // DELETE api/<MenuController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int Id)
        {
            //var Menu = Context.Menu.Find(Id);
            var Menu = Context.Menu.Include("SubMenu").FirstOrDefault(x => x.Id == Id);
            if (Menu == null)
            {
                return NotFound("Menu not Found");
            }
            else
            {
                Context.Menu.Remove(Menu);
                Context.SaveChanges();
                return Ok("Menu Deleted Successfully");
            }
        }
    }
}
