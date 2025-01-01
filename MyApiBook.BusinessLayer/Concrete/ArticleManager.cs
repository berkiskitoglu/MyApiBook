using MyApiBook.BusinessLayer.Abstract;
using MyApiBook.DataAccessLayer.Abstract;
using MyApiBook.DataAccessLayer.Dto;
using MyApiBook.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApiBook.BusinessLayer.Concrete
{
	public class ArticleManager : IArticleService
	{
		private readonly IArticleDal _articleDal;

		public ArticleManager(IArticleDal articleDal)
		{
			_articleDal = articleDal;
		}

		public List<ArticleWithAuthorAndBookApi> TArticleWithAuthorAndBookList()
		{
		  return _articleDal.ArticleWithAuthorAndBookList();
		}

		public void TDelete(int id)
		{
			_articleDal.Delete(id);
		}

		public List<Article> TGetAll()
		{
			return _articleDal.GetAll();
		}

		public Article TGetByID(int id)
		{
			return _articleDal.GetByID(id);
		}

		public void TInsert(Article entity)
		{
			_articleDal.Insert(entity);
		}

		public void TUpdate(Article entity)
		{
			_articleDal.Update(entity);
		}
	}
}
