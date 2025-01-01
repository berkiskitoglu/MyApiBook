using MyApiBook.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApiBook.DataAccessLayer.Abstract
{
    public interface IBookDal : IGenericDal<Book>
    {
        int GetBookCount();
        List<Book> BookWithCategoryAndAuthorList(int id);
        List<Book> BookWithCategoryAndAuthorList();
        List<Book> BookWithAuthorList();
       
     
    }
}
