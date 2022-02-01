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
    public class ColorsController : ControllerBase
    {
        //(post)add,update,delete;(get)getall,getby id
        IColorService _colorService;

        public ColorsController(IColorService colorService)
        {
            _colorService = colorService;
        }

        

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {

        }
        [HttpGet("GetById")]
        public IActionResult GetById(int colorId)
        {

        }
        [HttpPost("Add")]
        public IActionResult Add(Color color)
        {

        }
        [HttpPost("Update")]
        public IActionResult Update(Color color)
        {

        }
        [HttpPost("Delete")]
        public IActionResult Delete(Color color)
        {

        }
    }
}
