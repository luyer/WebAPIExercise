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
        public Post Add( [FromBody] Post newPost ){        
            int newID = this.posts.Count+1;
            Post nuevoPost = new Post {Id = newID, Title = newPost.Title  , Body = newPost.Body ,  Autor = newPost.Autor };
            this.posts.Add(nuevoPost);
            foreach (Post post in this.posts){
                if( post.Id == newID ){
                    return post;
                }
            }
            return null;
        }

        [HttpPut]
        public List<Post> Edit(  [FromBody] Post editedPost ){        

            foreach (Post post in this.posts){
                if( post.Id == editedPost.Id ){
                    post.Title = editedPost.Title;
                    post.Body = editedPost.Body;
                    //return post;
                }
            }

            return this.posts;

        }


        [HttpDelete("/[controller]/{id}")]
        public List<Post> Delete([FromRoute] long id){        
            //const string response = ;
    
            foreach (Post post in this.posts){
                if( post.Id == id ){
                    this.posts.Remove(post);
                    return this.posts;
                }
            }

            return this.posts;
        }



    }
}