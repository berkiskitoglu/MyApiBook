using MyApiBook.DataAccessLayer.Dto;
using MyApiBook.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApiBook.BusinessLayer.Abstract
{
	public interface IQuotationService : IGenericService<Quotation>
	{
		public List<QuotationWithAuthorApi> TQuatationWithAuthor();
	}
}
