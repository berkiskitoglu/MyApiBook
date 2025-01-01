using MyApiBook.BusinessLayer.Abstract;
using MyApiBook.DataAccessLayer.Abstract;
using MyApiBook.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApiBook.BusinessLayer.Concrete
{
    public class BookManager : IBookService
    {
        private readonly IBookDal _bookDal;

        public BookManager(IBookDal bookDal)
        {
            _bookDal = bookDal;
        }

		public List<Book> TBookWithCategoryAndAuthorList()
		{
            return _bookDal.BookWithCategoryAndAuthorList();
		}

		public List<Book> TBookWithAuthorList()
		{
           return _bookDal.BookWithAuthorList();
		}

		public List<Book> TBookWithCategoryAndAuthorList(int id)
		{
            return _bookDal.BookWithCategoryAndAuthorList(id);
		}

		public void TDelete(int id)
        {
            _bookDal.Delete(id);
        }

        public List<Book> TGetAll()
        {
            return _bookDal.GetAll();
        }

        public int TGetBookCount()
        {
           return _bookDal.GetBookCount();
        }

        public Book TGetByID(int id)
        {
            return _bookDal.GetByID(id);
        }


		public void TInsert(Book entity)
        {
            _bookDal.Insert(entity);
        }

        public void TUpdate(Book entity)
        {
            _bookDal.Update(entity);
        }
    }
}
