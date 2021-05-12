using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Autofac;
using TheShop.Domain.Models;
using TheShop.Application.Interfaces;
using TheShop.Domain.Interfaces;

namespace TheShop.Tests
{
    [TestClass]
    public class ServiceTest
    {
        [TestMethod]
        public void ServiceRegistered()
        {
            var container = Startup.GetContainer();

            var service = container.Resolve<IArticleService>();

            Assert.IsNotNull(service);
        }

        [TestMethod]
        public void TestFindArticle()
        {
            var container = Startup.GetContainer();

            var service = container.Resolve<IArticleService>();
            var repository = container.Resolve<IArticleRepository>();

            var article = new Article()
            {
                Id = 0,
                Name = "Test Add Article"
            };

            var createdArticle = repository.SaveArticle(article);

            var foundArticle = service.FindArticle(createdArticle.Id, Int32.MaxValue);

            Assert.IsNotNull(foundArticle);
            Assert.IsTrue(foundArticle.Id != 0);
        }

        [TestMethod]
        public void TestGetArticle()
        {
            var container = Startup.GetContainer();

            var repository = container.Resolve<IArticleRepository>();
            var service = container.Resolve<IArticleService>();

            var article = new Article()
            {
                Id = 0,
                Name = "Test Get Article"
            };

            var createdArticle = repository.SaveArticle(article);
            var selectedArticle = service.GetArticle(createdArticle.Id);

            Assert.IsTrue(selectedArticle.Id == createdArticle.Id && selectedArticle.Name == article.Name);

            selectedArticle = service.GetArticle(-1);

            Assert.IsNull(selectedArticle);

        }

        [TestMethod]
        public void TestSellArticle()
        {
            var container = Startup.GetContainer();

            var repository = container.Resolve<IArticleRepository>();
            var service = container.Resolve<IArticleService>();

            var article = new Article()
            {
                Id = 0,
                Name = "Test Update Article"
            };

            var createdArticle = repository.SaveArticle(article);


            var foundArticle = service.FindArticle(createdArticle.Id, Int32.MaxValue);

            service.SellArticle(foundArticle, 10);

            Assert.IsTrue(true);
        }
    }
}
