using Microsoft.EntityFrameworkCore;
using MyApiBook.DataAccessLayer.Abstract;
using MyApiBook.DataAccessLayer.Context;
using MyApiBook.DataAccessLayer.Dto;
using MyApiBook.DataAccessLayer.Repository;
using MyApiBook.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApiBook.DataAccessLayer.EntityFramework
{
	public class EfArticleDal : GenericRepositories<Article>, IArticleDal
	{
		public EfArticleDal(ApiContext context) : base(context)
		{
		}



		public List<ArticleWithAuthorAndBookApi> ArticleWithAuthorAndBookList()
		{
			var context = new ApiContext();

			// Article ile Author'ı dahil et
			var values = context.Articles.Include(x => x.Author)
										 .ThenInclude(x => x.Books) 
										 .ToList();

			
			var dto = values.Select(x => new ArticleWithAuthorAndBookApi
			{
				AuthorName = x.Author.AuthorName,
				AuthorSurname = x.Author.AuthorSurname,
				CreatedDate = x.CreatedDate,
				Description = x.Description,
				ArticleID = x.ArticleID,
				ImageUrl =  x.Author.Books.Select(y=>y.ImageUrl).ToList()
			
			}).ToList();

			return dto;
		}

	}
}
