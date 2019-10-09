using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;

namespace WebAPIExercise.Controllers
{

 

 
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    { 

        [HttpGet]
        public string Get(){        
            const string response = "Hola dude!";
            return response;
        }

     }


/*
public class GreetingController : ControllerBase
    {
        public string appName { get; set; }

        public GreetingController(IConfiguration config){
            appName = config.GetValue<string>("applicationName");
        }




 */



}