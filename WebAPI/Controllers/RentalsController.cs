using Business.Abstract;
using Entities.Concrete;
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
            var result = _rentalService.GetAll();
                if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);


        }
        [HttpGet("GetById")]
        public IActionResult GetById(int rentalId)
        {
            var result = _rentalService.GetById(rentalId);
                if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);

        }
        [HttpGet("getrentaldetails")]
        public IActionResult GetRentalsDetails()
        {
            var result = _rentalService.GetRentalsDetails();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        //-----------------------
        [HttpPost("Add")]
        public IActionResult Add(Rental rental)
        {
            var result = _rentalService.Add(rental);
                if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);
        }
        [HttpPost("Update")]
        public IActionResult Update(Rental rental)
        {
            var result = _rentalService.Update(rental);
                if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);
        }
        [HttpPost("Delete")]
        public IActionResult Delete(Rental rental)
        {
            var result = _rentalService.Delete(rental);
                if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);

        }
    }
}
