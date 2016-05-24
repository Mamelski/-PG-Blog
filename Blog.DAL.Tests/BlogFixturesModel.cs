namespace Blog.DAL.Tests
{
    using Blog.DAL.Model;

    using TDD.DbTestHelpers.Yaml;

    public class BlogFixturesModel
    {
        public FixtureTable<Post> Posts { get; set; }

        public FixtureTable<Comment> Comments { get; set; }
    }
}