namespace Blog.DAL.Model
{
    using System.ComponentModel.DataAnnotations;

    public class Comment
    {
        [Key]
        public long Id { get; set; }

        public long PostId { get; set; }

        [Required, MinLength(10)]
        public string Content { get; set; }
    }
}
