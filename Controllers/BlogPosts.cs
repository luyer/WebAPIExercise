using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebAPIExercise.Models;

namespace WebAPIExercise.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    //[Route("admin/[controller]")]
    public class BlogPosts : ControllerBase
    {

        private List<Post> posts;
        public BlogPosts(){
            this.posts = new List<Post> {
                new Post {Id = 1, Title = "Post 1", Body = "Cuerpo del post 1", Autor = "Luis" },
                new Post {Id = 2, Title = "Post 2", Body = "Cuerpo del post 2", Autor = "Eduardo" },
                new Post {Id = 3, Title = "Post 3", Body = "Cuerpo del post 3", Autor = "Marcelo" }
            };
        }


        [HttpGet]
        public List<Post> Index(){        
            //const string response = ;
            //return "Endpoint Get Index()";
            return this.posts;
        }


        [HttpGet("/[controller]/{id}")]
        public string View( int id  ){        
            //const string response = ;
            return "Endpoint Get Detalle registro";
        }


        [HttpPost]
        public List<Post> Add(  ){        
            int newID = this.posts.Count+1;
            Post nuevoPost = new Post {Id = newID, Title = "Post " + newID , Body = "body "+ newID,   Autor = "todos" };
            this.posts.Add(nuevoPost);
            return this.posts;
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