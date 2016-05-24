using System.ComponentModel.DataAnnotations;

namespace Blog.DAL.Model
{
    public class Post
    {
        [Key]
        public long Id { get; set; }

        [Required,MinLength(10)]
        public string Content { get; set; }

        [Required, MinLength(5)]
        public string Author { get; set; }
    }
}
