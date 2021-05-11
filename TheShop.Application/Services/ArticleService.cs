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
using TheShop.Supplier.Domain.Interfaces;
using TheShop.Supplier.Domain.Models;

namespace TheShop.Application.Services
{
    public class ArticleService : IArticleService
    {
        private readonly IArticleRepository _articleRepository;
        private readonly ILogger _logger;

        private readonly List<ISupplier> _suppliers;

        public ArticleService(IArticleRepository articleRepository,
            ILogger logger,
            IEnumerable<ISupplier> suppliers)
        {
            _articleRepository = articleRepository;
            _logger = logger;
            _suppliers = suppliers.ToList();
        }

        public Article GetById(int id)
        {
            return _articleRepository.GetArticle(id);
        }

        public SupplierArticle FindArticle(int id, int maxExpectedPrice)
        {
            return _suppliers.Where(s => s.ArticleInInventory(id))
                .Select(a => a.GetArticle(id))
                .FirstOrDefault(a => a.Price < maxExpectedPrice);
        }

        public void SellArticle(SupplierArticle article, int buyerId)
        {
            if (article == null)
            {
                throw new Exception("Could not order article");
            }

            _logger.Debug("Trying to sell article with id=" + article.Id);

            ArticleSale sale = new ArticleSale()
            {
                ArticleId = article.Id,
                BuyerId = buyerId,
                Date = DateTime.Now
            };

            try
            {
                _articleRepository.AddArticleSale(sale);
                _logger.Info("Article with id=" + article.Id + " is sold.");
            }
            catch (ArgumentNullException ex)
            {
                _logger.Error("Could not save article with id=" + article.Id);
                throw new Exception("Could not save article with id");
            }
            catch (Exception)
            {
            }
        }

        public Article GetArticle(int id)
        {
            return _articleRepository.GetArticle(id);
        }
    }
}
