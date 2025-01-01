using Microsoft.EntityFrameworkCore;
using MyApiBook.DataAccessLayer.Abstract;
using MyApiBook.DataAccessLayer.Context;
using MyApiBook.DataAccessLayer.Dto;
using MyApiBook.DataAccessLayer.Repository;
using MyApiBook.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApiBook.DataAccessLayer.EntityFramework
{
	public class EfQuotationDal : GenericRepositories<Quotation> , IQuotationDal
	{
		public EfQuotationDal(ApiContext context) : base(context)
		{
		}

		public List<QuotationWithAuthorApi> QuatationWithAuthor()
		{
			var context = new ApiContext();
			var values = context.Quotations.Include(x => x.Author).ToList();
			var dto = values.Select(x => new QuotationWithAuthorApi
			{
				AuthorID = x.AuthorID,
				AuthorName = x.Author.AuthorName,
				AuthorSurname = x.Author.AuthorSurname,
				QuatationID = x.QuatationID,
				Description = x.Description
			}).ToList();
			return dto;
		}

	
	}
}
