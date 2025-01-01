using MyApiBook.DataAccessLayer.Dto;
using MyApiBook.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApiBook.BusinessLayer.Abstract
{
	public interface IArticleService : IGenericService<Article>
	{
		public List<ArticleWithAuthorAndBookApi> TArticleWithAuthorAndBookList();
	}
}
