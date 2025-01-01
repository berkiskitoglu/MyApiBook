using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApiBook.EntityLayer.Concrete
{
	public class Quotation
	{
		[Key]
		public int QuatationID { get; set; }
		public string Description { get; set; }
		public int AuthorID { get; set; }
		public Author Author { get; set; }
	}
}
