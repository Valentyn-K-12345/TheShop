using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheShop.Supplier.Domain.Models;

namespace TheShop.Supplier.Domain.Interfaces
{
    public interface ISupplier
    {
        bool ArticleInInventory(int id);
        SupplierArticle GetArticle(int id);
    }
}
