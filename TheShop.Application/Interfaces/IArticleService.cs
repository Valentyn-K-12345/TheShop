using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheShop.Supplier.Domain.Models;

namespace TheShop.Application.Interfaces
{
    public interface IArticleService
    {
        SupplierArticle FindArticle(int id, int maxExpectedPrice);
        void SellArticle(SupplierArticle article, int buyerId);
    }
}
