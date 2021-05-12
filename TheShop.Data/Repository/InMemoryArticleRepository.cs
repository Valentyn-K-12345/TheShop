using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheShop.Domain.Interfaces;
using TheShop.Domain.Models;

namespace TheShop.Data.Repository
{
    public class InMemoryArticleRepository : IArticleRepository
    {
        private List<Article> _articles;
        private List<ArticleSale> _articaleSales;

        public InMemoryArticleRepository()
        {
            _articles = new List<Article>();
            _articaleSales = new List<ArticleSale>();
        }

        public Article SaveArticle(Article article)
        {
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

            return article;
        }

        public ArticleSale AddArticleSale(ArticleSale sale)
        {
            _articaleSales.Add(sale);
            return sale;
        }

        public Article GetArticle(int id)
        {
            return _articles.FirstOrDefault(a => a.Id == id);
        }
    }
}
