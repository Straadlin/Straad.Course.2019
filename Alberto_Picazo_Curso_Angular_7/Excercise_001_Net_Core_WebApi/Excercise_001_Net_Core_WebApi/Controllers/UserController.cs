using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Excercise_001_Net_Core_WebApi.Models;
using Microsoft.AspNetCore.Http;
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

        [HttpGet("users")]
        public ActionResult GetUsers()
        {
            var listUsers = new List<UserViewModel>();

            listUsers.Add(new UserViewModel
            {
                FirstName = "Alfredo",
                LastName = "Estrada",
                Email = "alfredo.estrada@straad.mx"
            });

            listUsers.Add(new UserViewModel
            {
                FirstName = "Amanda",
                LastName = "Gutiérrez",
                Email = "amanda@gmail.com"
            });

            listUsers.Add(new UserViewModel
            {
                FirstName = "Carolina",
                LastName = "Santos",
                Email = "carolina@gmail.com"
            });

            return Ok(listUsers);
        }

        [HttpPost("adduser")]
        public ActionResult AddUser([FromBody] UserViewModel model)
        {
            return Ok();
        }

        [HttpPost("image")]
        public async Task<ActionResult> PostImage(IFormFile image)
        {
            var filePath = Path.GetTempFileName();

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await image.CopyToAsync(stream);
            }

            // Do whenever we want.

            return Ok();
        }
    }
}