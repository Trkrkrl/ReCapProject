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

        }
        [HttpGet("GetById")]
        public IActionResult GetById(int customerId)
        {

        }
        [HttpPost("Add")]
        public IActionResult Add(Customer customer)
        {

        }
        [HttpPost("Update")]
        public IActionResult Update(Customer customer)
        {

        }
        [HttpPost("Delete")]
        public IActionResult Delete(Customer customer)
        {

        }

    }
}
