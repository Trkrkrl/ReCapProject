﻿using Business.Abstract;
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
    public class CarsController : ControllerBase
    {
        //(post)add,update,delete;(get)getall,getby id-- peki getbybrandid ve get cardetails i neden yapmıyoz??
        ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {

        }
        [HttpGet("GetById")]
        public IActionResult GetById(int carId)
        {

        }
        //-----------------------------------------------------
        [HttpPost("Add")]
        public IActionResult Add(Car car)
        {

        }
        [HttpPost("Update")]
        public IActionResult Update(Car car)
        {

        }
        [HttpPost("Delete")]
        public IActionResult Delete(Car car)
        {

        }
    }
}
