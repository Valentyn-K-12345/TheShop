using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheShop.Domain.Models;

namespace TheShop.Domain.Interfaces
{
    public interface IArticleRepository
    {
        Article GetArticle(int id);
        Article SaveArticle(Article article);
        ArticleSale AddArticleSale(ArticleSale sale);
    }
}
