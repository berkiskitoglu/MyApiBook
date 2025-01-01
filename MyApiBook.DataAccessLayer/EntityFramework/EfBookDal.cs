using Microsoft.EntityFrameworkCore;
using MyApiBook.DataAccessLayer.Abstract;
using MyApiBook.DataAccessLayer.Context;
using MyApiBook.DataAccessLayer.Repository;
using MyApiBook.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApiBook.DataAccessLayer.EntityFramework
{
    public class EfBookDal : GenericRepositories<Book>, IBookDal
    {
        public EfBookDal(ApiContext context) : base(context)
        {
        }

		public List<Book> BookWithAuthorList()
		{
            var context = new ApiContext();
            var values = context.Books.Include(x => x.Category).Include(x=>x.Author).ToList();
            return values;
		}

		public List<Book> BookWithCategoryAndAuthorList(int id)
		{
            var context = new ApiContext();
            var values = context.Books.Include(x=>x.Category).Include(y=>y.Author).Where(z=>z.CategoryID == id).ToList();
            return values;


        }

		public List<Book> BookWithCategoryAndAuthorList()
		{
			var context = new ApiContext();
			var values = context.Books.Include(x => x.Category).Include(y => y.Author).ToList();
			return values;
		}

		public int GetBookCount()
        {
            var context = new ApiContext();
            int value = context.Books.Count();
            return value;
        }

	
	}
}
