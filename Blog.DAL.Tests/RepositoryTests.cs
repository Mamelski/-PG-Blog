using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using Blog.DAL.Infrastructure;
using Blog.DAL.Model;
using Blog.DAL.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace Blog.DAL.Tests
{
    using System.ComponentModel.DataAnnotations;

    using TDD.DbTestHelpers.Core;

    [TestClass]
    public class RepositoryTests : DbBaseTest<BlogFixtures>
    {
        [TestMethod]
        public void GetAllPost_OnePostInDb_ReturnOnePost()
        {
            // arrange
            var context = new BlogContext();
            context.Database.CreateIfNotExists();
            var repository = new BlogRepository();
            // act
            var result = repository.GetAllPosts();
            // assert
            Assert.AreEqual(1, result.Count());
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public void AddInvalidPost()
        {
            // arrange
            var context = new BlogContext();
            context.Database.CreateIfNotExists();
            var repository = new BlogRepository();
            // act
             repository.AddPost(new Post());
           
        }

        [TestMethod]
        public void AddValidPost()
        {
            // arrange
            var context = new BlogContext();
            context.Database.CreateIfNotExists();
            var repository = new BlogRepository();
            // act
            repository.AddPost(new Post {Author = "asdasda", Content = "aaaaaaaaaaaaaaaaaaaaaaa"});
            var result = repository.GetAllPosts();
            // assert
            Assert.AreEqual(2, result.Count());
        }

        [TestMethod]
        public void GetAllComments()
        {
            // arrange
            var context = new BlogContext();
            context.Database.CreateIfNotExists();
            var repository = new BlogRepository();
            // act
            var result = repository.GetCommentsToPost(new Post { Id = 1}).Count();
            // assert
            Assert.AreEqual(1,result);
        }

        [TestMethod]
        public void AddValidComment()
        {
            // arrange
            var context = new BlogContext();
            context.Database.CreateIfNotExists();
            var repository = new BlogRepository();
            // act
            repository.AddComment(new Comment {Content = "aaaaaaaaaaaaaaaaaaaaaaa" });
            var result = repository.GetAllPosts();
            // assert
            Assert.AreEqual(1, result.Count());
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public void AddInvalidComment()
        {
            // arrange
            var context = new BlogContext();
            context.Database.CreateIfNotExists();
            var repository = new BlogRepository();
            // act
            repository.AddComment(new Comment());
        }
    }
}
