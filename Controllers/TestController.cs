using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace WebAPIExercise.Controllers
{

    [ApiController]
    [Route("[controller]")]

    public class TestController : ControllerBase{
        [HttpGet]
        public string Get(){
            const string response = "Hola dude!";
            return  response;
        }

    }

}