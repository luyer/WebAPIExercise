using System.Collections.Generic;
using System.Linq;
using WebAPIExercise.Data;
using WebAPIExercise.Data.Models;

namespace WebAPIExercise.Services.PostService
{
    public class InMemoryPostDb : IPostService
    {
        
        private WebAPIExerciseContext context;
        
        public InMemoryPostDb( WebAPIExerciseContext context ){
            this.context = context;
        }


        public Post Add(Post newPost)
        {
            var addedPost = this.context.Posts.Add(newPost);
            this.context.SaveChanges();
            return addedPost.Entity;

        }

        public IList<Post> GetAll()
        {
            return this.context.Posts.ToList();
            //throw new System.NotImplementedException();
        }

        public Post GetById(long id)
        {
            return this.context.Posts.Find(id);
            //throw new System.NotImplementedException();
        }

        public void Update(Post updatedPost)
        {
            this.context.Posts.Update(updatedPost);
            this.context.SaveChanges();
            //throw new System.NotImplementedException();
        }

       public Post Delete(long id)
        {
            var deletedPost = this.context.Posts.Find(id);
            this.context.Posts.Remove(deletedPost);
            this.context.SaveChanges();
            return deletedPost;
            //throw new System.NotImplementedException();
        }

    }
}