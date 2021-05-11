using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheShop.Supplier.Domain.Interfaces;
using TheShop.Supplier.Domain.Models;

namespace TheShop.Application.Suppliers
{
    public class Supplier3 : ISupplier
    {
        public bool ArticleInInventory(int id)
        {
            return true;
        }

        public SupplierArticle GetArticle(int id)
        {
            return new SupplierArticle()
            {
                Id = 1,
                Name = "Article from supplier1",
                Price = 460
            };
        }
    }
}
