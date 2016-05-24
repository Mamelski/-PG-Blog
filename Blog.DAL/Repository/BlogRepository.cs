using System.Collections.Generic;
using Blog.DAL.Infrastructure;
using Blog.DAL.Model;

namespace Blog.DAL.Repository
{
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class BlogRepository
    {
        private readonly BlogContext _context;

        public BlogRepository()
        {
            _context = new BlogContext();
        }

        public IEnumerable<Post> GetAllPosts()
        {
            return _context.Posts;
        }

        public void AddPost(Post post)
        {
            var res = new List<ValidationResult>();
            if (!Validator.TryValidateObject(post, new ValidationContext(post, null, null), res))
            {
                throw new ValidationException("ValidationFailed");
            }

            _context.Posts.Add(post);
            _context.SaveChanges();
        }

        public IEnumerable<Comment> GetCommentsToPost(Post post)
        {
            return _context.Comments.Where(c => c.PostId == post.Id);
        }

        public void AddComment(Post post, Comment comment)
        {
            var results = new List<ValidationResult>();
            if (!Validator.TryValidateObject(comment, new ValidationContext(comment, serviceProvider: null, items: null), results))
                throw new ValidationException(results.First()?.ErrorMessage);

           // _context.Posts.Find(post.Id).Comments.Add(comment);
            //_context.SaveChanges();
        }
    }
}
