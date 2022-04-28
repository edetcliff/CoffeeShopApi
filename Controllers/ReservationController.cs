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
    public class ReservationController : ControllerBase
    {
        CoffeeShopApiDbContext Context;
        public ReservationController(CoffeeShopApiDbContext DbContext)
        {
            Context = DbContext;
        }
        //The routes below is for the admin 
        
        //Paging 
        [HttpGet("[action]")]
        public IActionResult Paging(int? pageNumber, int? pageSize)
        {
            var reservation = Context.Reservation;
            var currentPageNumber = pageNumber ?? 1;
            var currentPageSize = pageSize ?? 5;
            return Ok(reservation.Skip((currentPageNumber - 1) * currentPageSize).Take(currentPageSize));
        }

        //Search
        [HttpGet]
        [Route("[action]")]
        public IActionResult Search(string text)
        {
            var reservation = Context.Reservation.Where(x => x.FirstName.StartsWith(text));
            return Ok(reservation);
        }

        //Sort
        [HttpGet("[action]")]
        [ResponseCache(Duration = 60, Location = ResponseCacheLocation.Any)]
        //[AllowAnonymous]
        public IActionResult Sort(string sort)
        {
            IQueryable<Reservation> reservation;
            switch(sort)
            {
                case "desc":
                    reservation = Context.Reservation.OrderByDescending(k => k.Date);
                    break;
                case "asc":
                    reservation = Context.Reservation.OrderBy(k => k.Date);
                    break;
                default:
                    reservation = Context.Reservation;
                    break;
            }

            return Ok(reservation);
        }


        //This route is for the user to be able to book RESERVATION

        // POST api/<ReservationController>
        [HttpPost]
        public IActionResult Post([FromBody] Reservation reservation)
        {
            Context.Reservation.Add(reservation);
            Context.SaveChanges();
            return StatusCode(StatusCodes.Status201Created);
        }

       
    }
}
