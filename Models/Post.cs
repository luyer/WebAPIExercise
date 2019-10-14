using System.ComponentModel.DataAnnotations;

namespace WebAPIExercise.Models
{
    public class Post
    {
        public long Id { get; set; }
        
        [MaxLength(10)]
        public string Title { get; set; }
        
        [MaxLength(30)]
         public string Body { get; set; }
         
         [MaxLength(15)]
         public string Autor { get; set; }
    }
}