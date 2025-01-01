using MyApiBook.BusinessLayer.Abstract;
using MyApiBook.DataAccessLayer.Abstract;
using MyApiBook.DataAccessLayer.Dto;
using MyApiBook.DataAccessLayer.EntityFramework;
using MyApiBook.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApiBook.BusinessLayer.Concrete
{
	public class QuotationManager : IQuotationService
	{
		private readonly IQuotationDal _quatationDal;

		public QuotationManager(IQuotationDal quatationDal)
		{
			_quatationDal = quatationDal;
		}

		public void TDelete(int id)
		{
			_quatationDal.Delete(id);
		}

		public List<Quotation> TGetAll()
		{
			return _quatationDal.GetAll();
		}

		public Quotation TGetByID(int id)
		{
			return _quatationDal.GetByID(id);
		}

		public void TInsert(Quotation entity)
		{
			_quatationDal.Insert(entity);
		}

		public List<QuotationWithAuthorApi> TQuatationWithAuthor()
		{
			return _quatationDal.QuatationWithAuthor();
		}

		public void TUpdate(Quotation entity)
		{
			_quatationDal.Update(entity);
		}
	}
}
