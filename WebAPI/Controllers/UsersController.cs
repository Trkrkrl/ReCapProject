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
    public class UsersController : ControllerBase
    {
        //(post)add,update,delete;(get)getall,getby id
        IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {

        }
        [HttpGet("GetById")]
        public IActionResult GetById(int userId)
        {

        }
        [HttpPost("Add")]
        public IActionResult Add(User user)
        {

        }
        [HttpPost("Update")]
        public IActionResult Update(User user)
        {

        }
        [HttpPost("Delete")]
        public IActionResult Delete(User user)
        {

        }
    }
}
