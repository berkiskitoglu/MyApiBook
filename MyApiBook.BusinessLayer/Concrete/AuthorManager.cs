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
    public class AuthorManager : IAuthorService
    {
        private readonly IAuthorDal _authorDal;

        public AuthorManager(IAuthorDal authorDal)
        {
            _authorDal = authorDal;
        }

        public void TDelete(int id)
        {
            _authorDal.Delete(id);
        }

        public List<Author> TGetAll()
        {
            return _authorDal.GetAll();
        }

        public Author TGetByID(int id)
        {
            return _authorDal.GetByID(id);
        }

        public void TInsert(Author entity)
        {
            _authorDal.Insert(entity);
        }

        public void TUpdate(Author entity)
        {
            _authorDal.Update(entity);
        }
    }
}
