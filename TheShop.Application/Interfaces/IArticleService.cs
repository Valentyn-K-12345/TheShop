using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheShop.Application.Interfaces
{
    public interface IArticleService
    {
        void OrderAndSellArticle(int id, int maxExpectedPrice, int buyerId);
    }
}
