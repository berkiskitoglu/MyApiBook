using MyApiBook.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApiBook.BusinessLayer.Abstract
{
    public interface IBookService : IGenericService<Book>
    {
        public int TGetBookCount();
        public List<Book> TBookWithCategoryAndAuthorList(int id);
        public List<Book> TBookWithCategoryAndAuthorList();

		public List<Book> TBookWithAuthorList();
	}
}
