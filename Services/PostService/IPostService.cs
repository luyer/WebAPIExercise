using System.Collections.Generic;
using WebAPIExercise.Data.Models;

namespace WebAPIExercise.Services.PostService
{
    public interface IPostService
    {
         IList<Post> GetAll();

         Post GetById(long id);

         Post Add(Post newPost);

         void Update(Post updatedPost);

         //void Delete(Post deletedPost);
        IList<Post> Delete(long id);
    }
}