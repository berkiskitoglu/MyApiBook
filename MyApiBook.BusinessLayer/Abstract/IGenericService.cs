using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApiBook.BusinessLayer.Abstract
{
    public interface IGenericService<T> where T:class
    {
        public void TInsert(T entity);
        public void TDelete(int id);
        public void TUpdate(T entity);
        T TGetByID(int id);
        List<T> TGetAll();
    }
}
