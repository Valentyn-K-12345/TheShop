using Autofac;
using System;
using TheShop.Application.Interfaces;

namespace TheShop
{
	internal class Program
	{
		private static void Main(string[] args)
		{           
            var container = Startup.GetContainer();

            var articleService = container.Resolve<IArticleService>();


            try
			{
				//order and sell
				var article = articleService.FindArticle(1, 20);
                articleService.SellArticle(article, 10);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
			}

			try
			{
				//print article on console
				var article = articleService.GetArticle(1);
				Console.WriteLine("Found article with ID: " + article.Id);
			}
			catch (Exception ex)
			{
				Console.WriteLine("Article not found: " + ex);
			}

			try
			{
				//print article on console				
				var article = articleService.GetArticle(12);
				Console.WriteLine("Found article with ID: " + article.Id);
			}
			catch (Exception ex)
			{
				Console.WriteLine("Article not found: " + ex);
			}

			Console.ReadKey();
		}
	}
}