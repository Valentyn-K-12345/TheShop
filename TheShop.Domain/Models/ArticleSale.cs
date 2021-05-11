using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheShop.Domain.Models
{
    public class ArticleSale
    {
        public int ArticleId { get; set; }
        public int BuyerId { get; set; }
        public DateTime Date { get; set; }
    }
}
