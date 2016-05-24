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

      

 

        //[TestMethod]
        //public void A()
        //{
        //    // arrange
        //    var context = new BlogContext();
        //    context.Database.CreateIfNotExists();
        //    var repository = new BlogRepository();
        //    // act
        //    var result = repository.ge
        //    // assert
        //    Assert.IsFalse(result);
        //}
    }
}
