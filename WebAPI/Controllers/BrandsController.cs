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
    public class BrandsController : ControllerBase
    {//(post)add,update delete;(get)getall,getbyid
        IBrandService _brandService;

        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }


        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {

        }
        [HttpGet("GetById")]
        public IActionResult GetById(int brandId)
        {

        }
        [HttpPost("Add"]
        public IActionResult Add(Brand brand)
        {

        }
        [HttpPost("Update"]
        public IActionResult Update(Brand brand)
        {

        }
        [HttpPost("Delete"]
        public IActionResult Delete(Brand brand)
        {

        }


    }
}
