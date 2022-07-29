using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharactelController : ControllerBase
    {
        private static Character knight = new Character();

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(knight);
        }
    }
}