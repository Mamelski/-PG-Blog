namespace Blog.DAL.Tests
{
    using Infrastructure;

    using TDD.DbTestHelpers.Yaml;

    public class BlogFixtures : YamlDbFixture<BlogContext, BlogFixturesModel>
    {
        public BlogFixtures()
        {
            SetYamlFiles("posts.yml");
        }
    }
}