using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using WebAPIExercise.Models;

namespace WebAPIExercise.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    { 

        private List<Customer> customers;

        public TestController()
        {
            this.customers = new List<Customer> {
                new Customer { Id = 1, FirstName = "steve", Lastname = "Balh", Email = "correo@bla.com"  },
                new Customer { Id = 2, FirstName = "luis", Lastname = "Balh", Email = "luis@bla.com"  }
            };
        }



        [HttpGet]
        public IActionResult GetAll(  ){        
            
            return Ok(this.customers);

        }



        [HttpGet]
        [Route("{id}")]
        public IActionResult Get( [FromRoute] long id ){        
            foreach (Customer customer in this.customers){
                if(customer.Id == id){
                    //OkObjectResult result = new OkObjectResult(customer);
                    //return result;
                    //return base.Ok(customer);
                    return Ok(customer);
                }

            }
            //return new NotFoundObjectResult("No encontramos naa");
            //return base.NotFound(new {errorMessage = "No encontramos naa", errorCode = 2  });
            //return NotFound(new {errorMessage = "No encontramos naa", errorCode = 2  });
            return NotFound();
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