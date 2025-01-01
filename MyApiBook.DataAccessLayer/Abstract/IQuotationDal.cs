using MyApiBook.DataAccessLayer.Dto;
using MyApiBook.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApiBook.DataAccessLayer.Abstract
{
	public interface IQuotationDal : IGenericDal<Quotation>
	{
		List<QuotationWithAuthorApi> QuatationWithAuthor();
	}
}
