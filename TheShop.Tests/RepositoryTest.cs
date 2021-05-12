using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Autofac;
using TheShop.Domain.Interfaces;
using TheShop.Domain.Models;

namespace TheShop.Tests
{
    [TestClass]
    public class RepositoryTest
    {
        [TestMethod]
        public void RepositoryRegistered()
        {
            var container = Startup.GetContainer();

            var repository = container.Resolve<IArticleRepository>();

            Assert.IsNotNull(repository);
        }

        [TestMethod]
        public void TestAddArticle()
        {
            var container = Startup.GetContainer();

            var repository = container.Resolve<IArticleRepository>();

            var article = new Article()
            {
                Id = 0,
                Name = "Test Add Article"
            };

            var createdArticle = repository.SaveArticle(article);

            Assert.IsTrue(createdArticle.Id != 0);
        }

        [TestMethod]
        public void TestGetArticle()
        {
            var container = Startup.GetContainer();

            var repository = container.Resolve<IArticleRepository>();

            var article = new Article()
            {
                Id = 0,
                Name = "Test Get Article"
            };

            var createdArticle = repository.SaveArticle(article);
            var selectedArticle = repository.GetArticle(createdArticle.Id);

            Assert.IsTrue(selectedArticle.Id == createdArticle.Id && selectedArticle.Name == article.Name);

            selectedArticle = repository.GetArticle(-1);

            Assert.IsNull(selectedArticle);

        }

        [TestMethod]
        public void TestUpdateArticle()
        {
            var container = Startup.GetContainer();

            var repository = container.Resolve<IArticleRepository>();

            var article = new Article()
            {
                Id = 0,
                Name = "Test Update Article"
            };

            var createdArticle = repository.SaveArticle(article);

            createdArticle.Name = "Test Update Article updated";

            var updatedArticle = repository.SaveArticle(createdArticle);

            var selectedArticle = repository.GetArticle(createdArticle.Id);


            Assert.IsTrue(selectedArticle.Name == "Test Update Article updated");
        }
    }
}
