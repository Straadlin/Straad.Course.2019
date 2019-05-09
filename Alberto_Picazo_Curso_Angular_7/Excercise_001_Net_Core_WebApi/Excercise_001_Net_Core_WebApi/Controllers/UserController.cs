using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Excercise_001_Net_Core_WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace Excercise_001_Net_Core_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            return Ok(new
            {
                FirstName = "Alfredo",
                LastName = "Estrada",
                Email = "alfredo.estrada@straad.mx"
            });
        }

        [HttpPost("adduser")]
        public ActionResult AddUser([FromBody] UserViewModel model)
        {
            return Ok();
        }
    }
}