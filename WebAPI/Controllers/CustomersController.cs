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
    public class CustomersController : ControllerBase
    {//(post)add,update,delete;(get)getall,getby id
        ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _customerService.GetAll();
                if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);

        }
        [HttpGet("GetById")]
        public IActionResult GetById(int customerId)
        {
            var result = _customerService.GetById(customerId);
                if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);

        }
        //------------------sonradan eklendi
        [HttpGet("getbyuserid")]
        public IActionResult GetByUserId(int userId)
        {
            var result = _customerService.GetByUserId(userId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        //-----------
        [HttpPost("Add")]
        public IActionResult Add(Customer customer)
        {
            var result = _customerService.Add(customer);
                if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);

        }
        [HttpPost("Update")]
        public IActionResult Update(Customer customer)
        {
            var result = _customerService.Update(customer);
                if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);

        }
        [HttpPost("Delete")]
        public IActionResult Delete(Customer customer)
        {
            var result = _customerService.Delete(customer);
                if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);

        }

    }
}
