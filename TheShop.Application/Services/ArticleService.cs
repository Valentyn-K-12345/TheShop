using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheShop.Application.Interfaces;
using TheShop.Application.Suppliers;
using TheShop.Core.Logger;
using TheShop.Domain.Interfaces;
using TheShop.Domain.Models;
using TheShop.Supplier.Domain.Models;

namespace TheShop.Application.Services
{
    public class ArticleService : IArticleService
    {
        private IArticleRepository _articleRepository;
        private ILogger _logger;

        private Supplier1 Supplier1;
        private Supplier2 Supplier2;
        private Supplier3 Supplier3;

        public ArticleService(IArticleRepository articleRepository,
            ILogger logger)
        {
            _articleRepository = articleRepository;
            _logger = logger;
            Supplier1 = new Supplier1();
            Supplier2 = new Supplier2();
            Supplier3 = new Supplier3();
        }

        public void OrderAndSellArticle(int id, int maxExpectedPrice, int buyerId)
        {
            #region ordering article

            SupplierArticle article = null;
            SupplierArticle tempArticle = null;
            var articleExists = Supplier1.ArticleInInventory(id);
            if (articleExists)
            {
                tempArticle = Supplier1.GetArticle(id);
                if (maxExpectedPrice < tempArticle.Price)
                {
                    articleExists = Supplier2.ArticleInInventory(id);
                    if (articleExists)
                    {
                        tempArticle = Supplier2.GetArticle(id);
                        if (maxExpectedPrice < tempArticle.Price)
                        {
                            articleExists = Supplier3.ArticleInInventory(id);
                            if (articleExists)
                            {
                                tempArticle = Supplier3.GetArticle(id);
                                if (maxExpectedPrice < tempArticle.Price)
                                {
                                    article = tempArticle;
                                }
                            }
                        }
                    }
                }
            }

            article = tempArticle;
            #endregion

            #region selling article

            if (article == null)
            {
                throw new Exception("Could not order article");
            }

            _logger.Debug("Trying to sell article with id=" + id);

            ArticleSale sale = new ArticleSale()
            {
                ArticleId = article.Id,
                BuyerId = buyerId,
                Date = DateTime.Now
            };

            try
            {
                _articleRepository.AddArticleSale(sale);
                _logger.Info("Article with id=" + id + " is sold.");
            }
            catch (ArgumentNullException ex)
            {
                _logger.Error("Could not save article with id=" + id);
                throw new Exception("Could not save article with id");
            }
            catch (Exception)
            {
            }

            #endregion
        }

        public Article GetById(int id)
        {
            return _articleRepository.GetArticle(id);
        }
    }
}
