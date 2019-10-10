using Microsoft.AspNetCore.Mvc;

namespace WebAPIExercise.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    //[Route("admin/[controller]")]
    public class BlogPosts : ControllerBase
    {

        [HttpGet]
        public string Index(){        
            //const string response = ;
            return "Endpoint Get Index()";
        }

 /* 
        [HttpGet]
        public string View( int id  ){        
            //const string response = ;
            return "Endpoint Get Detalle registro";
        }
*/

        [HttpPost]
        public string Add(){        
            //const string response = ;
            return "Endpoint Post Add()";
        }

        [HttpPut]
        public string Edit(){        
            //const string response = ;
            return "Endpoint Put Edit()";
        }


        [HttpDelete]
        public string Delete(){        
            //const string response = ;
            return "Endpoint Delete Delete()";
        }



    }
}