using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : ControllerBase
    {//(post)add,update,delete;(get)getall,getby id
        IRentalService _rentalService;

        public RentalsController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {

        }
        [HttpGet("GetById")]
        public IActionResult GetById(int rentalId)
        {

        }
        [HttpPost("Add")]
        public IActionResult Add(Rental rental)
        {

        }
        [HttpPost("Update")]
        public IActionResult Update(Rental rental)
        {

        }
        [HttpPost("Delete")]
        public IActionResult Delete(Rental rental)
        {

        }
    }
}
