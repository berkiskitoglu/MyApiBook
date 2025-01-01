using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApiBook.DataAccessLayer.Dto
{
	public class ArticleWithAuthorAndBookApi
	{
		public int ArticleID { get; set; }
		public DateTime CreatedDate { get; set; }

		public string Description { get; set; }
		public string AuthorName { get; set; }
		public string AuthorSurname { get; set; }
		public List<String> ImageUrl { get; set; }
	}
}
