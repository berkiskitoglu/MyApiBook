using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApiBook.DataAccessLayer.Dto
{
	public class QuotationWithAuthorApi
	{
		public int QuatationID { get; set; }
		public string Description { get; set; }
		public int AuthorID { get; set; }
		public string AuthorName { get; set; }
		public string AuthorSurname { get; set; }
	}
}
