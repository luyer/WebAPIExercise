using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebAPIExercise.Data.Models;
using WebAPIExercise.Services.PostService;

namespace WebAPIExercise.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    //[Route("admin/[controller]")]
    public class BlogPosts : ControllerBase
    {


        private IPostService postsService;
        public BlogPosts(IPostService postsService){
            //this.postsService = postsService ?? new InMemoryPosts();
            this.postsService = postsService;
        }


        [HttpGet]
        public IActionResult Index(){        
            //const string response = ;
            //return "Endpoint Get Index()";
            //return this.posts;
            //return Ok(this.posts);
            return Ok(this.postsService);
        }


        [HttpGet("/[controller]/[action]/{id}")]
        [Consumes("application/xml")]  
        public IActionResult View([FromRoute] long id  ){                  
            var serviceResponse  = this.postsService.GetById(id);
            if( serviceResponse != null ) return Ok(serviceResponse);
            return NotFound( new {errorMessage = "el Id pasado no existe" } );
        }


        [HttpPost]
        public IActionResult Add( [FromBody] Post newPost ){        
            
            if( ModelState.IsValid ){    
                var serviceResponse = this.postsService.Add(newPost);
                 return Ok(View(serviceResponse.Id));
            }
            return ValidationProblem();
        }

        [HttpPut]
        public IActionResult Edit(  [FromBody] Post editedPost ){        
            if( ModelState.IsValid ){
                 this.postsService.Update(editedPost);
            }
            //return this.posts;
            return ValidationProblem();
        }


        [HttpDelete("/[controller]/{id}")]
        public IActionResult Delete([FromRoute] long id){        
            //const string response = ;
            
            var serviceResponse = this.postsService.Delete(id);
            if( serviceResponse != null ) return Ok(serviceResponse);
            return BadRequest();
            //return this.posts;
            
        }



    }
}