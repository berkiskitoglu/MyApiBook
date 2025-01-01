using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApiBook.DataAccessLayer.Abstract
{
    public interface IGenericDal<T> where T:class
    {
        public void Insert(T entity);
        public void Delete(int id);
        public void Update(T entity);
        T GetByID(int id);
        List<T> GetAll();
    }
}
