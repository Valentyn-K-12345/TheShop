using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheShop.Core.Logger;
using TheShop.Domain.Interfaces;
using TheShop.Domain.Models;

namespace TheShop.Data.Repository
{
    public class InMemoryArticleRepository : IArticleRepository
    {
        private List<Article> _articles;
        private List<ArticleSale> _articaleSales;

        private readonly ILogger _logger;

        public InMemoryArticleRepository(ILogger logger)
        {
            _logger = logger;
            _articles = new List<Article>();
            _articaleSales = new List<ArticleSale>();
        }

        public Article SaveArticle(Article article)
        {
            if(article == null)
            {
                throw new ArgumentNullException(nameof(article));
            }

            _logger.Debug($" >> Saving article with Name: {article.Name}");
            //simple upsert
            if(article.Id == 0)
            {
                article.Id = _articles.Count != 0 ? _articles.Max(a => a.Id) + 1 : 1;
            }
            else
            {
                _articles.RemoveAll(a => a.Id == article.Id);
            }
            _articles.Add(article);

            _logger.Debug($" << saved article with Name: {article.Name} and Id: {article.Id}");


            return article;
        }

        public ArticleSale AddArticleSale(ArticleSale sale)
        {
            if (sale == null)
            {
                throw new ArgumentNullException(nameof(sale));
            }

            _logger.Debug($" >> Saving article sale with article id: {sale.ArticleId} and buyerId: {sale.BuyerId}");

            _articaleSales.Add(sale);

            _logger.Debug($" << saved article sale with article id: {sale.ArticleId} and buyerId: {sale.BuyerId}");

            return sale;
        }

        public Article GetArticle(int id)
        {
            _logger.Debug($" >> getting article with id: {id}");

            return _articles.FirstOrDefault(a => a.Id == id);
        }
    }
}
