using System.Collections.Generic;
using WebAPIExercise.Data.Models;


namespace WebAPIExercise.Services.PostService
{
    public class InMemoryPosts : IPostService
    {

        private IList<Post> posts;

        public InMemoryPosts( IList<Post> posts = null ){
            if(posts==null){
                new List<Post>();
            }else{
                this.posts = posts;
            }
        }
        
        public IList<Post> GetAll()
        {
            return this.posts;
            //throw new System.NotImplementedException();
        }

        public Post GetById(long id)
        {
            foreach (Post post in this.posts){
                if( post.Id == id ){
                    return post;
                }
            }
            return null;            
            //throw new System.NotImplementedException();
        }

        public Post Add(Post newPost)
        {

                int newID = this.posts.Count+1;
                Post nuevoPost = new Post {Id = newID, Title = newPost.Title  , Body = newPost.Body ,  Autor = newPost.Autor };
                this.posts.Add(nuevoPost);
                return nuevoPost;
            //throw new System.NotImplementedException();
        }

        public void Update(Post updatedPost)
        {
            
            foreach (Post post in this.posts){
                if( post.Id == updatedPost.Id ){
                    post.Title = updatedPost.Title;
                    post.Body = updatedPost.Body;
                    post.Autor = updatedPost.Autor;
                    break;
                }
            }            
            //throw new System.NotImplementedException();
        }


        public IList<Post> Delete(long id)
        {
             foreach (Post post in this.posts){
                if( post.Id == id ){
                    this.posts.Remove(post);
                    return this.posts;
                }
            }
            return null;           
            //throw new System.NotImplementedException();
        }

    }
}